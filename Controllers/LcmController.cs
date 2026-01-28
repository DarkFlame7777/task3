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
            if (!BigInteger.TryParse(x, out BigInteger xValue) ||
                !BigInteger.TryParse(y, out BigInteger yValue))
            {
                return Content("NaN", "text/plain");
            }

            if (xValue <= 0 || yValue <= 0)
                return Content("NaN", "text/plain");
            
            return Content(CalculateLcm(xValue, yValue).ToString(), "text/plain");
        }

        private BigInteger CalculateLcm(BigInteger a, BigInteger b) => BigInteger.Abs(a * b) / Gcd(a, b);

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
