using CarBook.Dto.FeatureDtos;
using CarBook.Dto.LoginDtos;
using CarBook.Dto.RegisterDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook.WebUI.Controllers 
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Oturum";
            ViewBag.v2 = "Giriş Yap";
            if (Request.Query.ContainsKey("ReturnUrl") || User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequestDto loginRequestDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(loginRequestDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7131/api/Login", stringContent);

            if (response.IsSuccessStatusCode)  
            {
                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jwtResponseModel = JsonConvert.DeserializeObject<JwtResponseModel>(responseContent);
                    if (jwtResponseModel != null)
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(jwtResponseModel.AccessToken);
                        var claims = token.Claims.ToList();

                        if(jwtResponseModel.AccessToken != null)
                        {
                            claims.Add(new Claim("AccessToken", jwtResponseModel.AccessToken));
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var authProps = new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = jwtResponseModel.Expiration
                            };
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                            return RedirectToAction("Index", "Default");
                        }
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); 
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
