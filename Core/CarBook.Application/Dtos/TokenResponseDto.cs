using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string accessToken, DateTime expiration)
        {
            AccessToken = accessToken;
            Expiration = expiration;
        }

        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
