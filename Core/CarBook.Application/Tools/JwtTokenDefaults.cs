using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string Issuer = "https://localhost";
        public const string Audience = "https://localhost";
        public const int ExpirationMinutes = 10;
        public const string SecurityKey = "CarBookSecurityKey*123456_123456*"; 
    }
}
