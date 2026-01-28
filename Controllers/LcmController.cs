using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Text;

namespace Task3.Controllers
{
    [ApiController]
    [Route("player859_yandex_by")] 
    public class LcmController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalculateLcm([FromQuery] string? x, [FromQuery] string? y)
        {
            x = x?.Trim();
            y = y?.Trim();
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return Content("NaN", "text/plain", Encoding.UTF8);
            if (!BigInteger.TryParse(x, out BigInteger xValue) ||
                !BigInteger.TryParse(y, out BigInteger yValue))
            {
                return Content("NaN", "text/plain", Encoding.UTF8);
            }
            if (xValue <= 0 || yValue <= 0)
                return Content("NaN", "text/plain", Encoding.UTF8);
            BigInteger result = CalculateLcmInternal(xValue, yValue);
            return Content(result.ToString(), "text/plain", Encoding.UTF8);
        }

        private BigInteger CalculateLcmInternal(BigInteger a, BigInteger b)
        {
            BigInteger gcd = Gcd(a, b);
            return (a / gcd) * b;
        }

        private BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}

