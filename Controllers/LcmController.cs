using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

namespace Task3.Controllers
{
    [ApiController]
    [Route("player859_yandex_by")] 
    public class LcmController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalculateLcm([FromQuery] string x, [FromQuery] string y)
        {
            x = x?.Trim();
            y = y?.Trim();

            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
                return Content("NaN", "text/plain");

            if (!BigInteger.TryParse(x, out BigInteger xValue) ||
                !BigInteger.TryParse(y, out BigInteger yValue))
            {
                return Content("NaN", "text/plain");
            }

            if (xValue <= 0 || yValue <= 0)
                return Content("NaN", "text/plain");
            BigInteger lcm = SafeCalculateLcm(xValue, yValue);
            return Content(lcm.ToString(), "text/plain");
        }

        private BigInteger SafeCalculateLcm(BigInteger a, BigInteger b)
        {
            BigInteger gcd = Gcd(a, b);
            return BigInteger.Abs(a) * (BigInteger.Abs(b) / gcd);
        }

        private BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return BigInteger.Abs(a); 
        }
    }
}
