using Microsoft.AspNetCore.Mvc;
using System;

namespace Task3.Controllers
{
    [ApiController]
    [Route("player859_yandex_by")]
    public class LcmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CalculateLcm([FromQuery] string x, [FromQuery] string y)
        {
            // Проверяем входные параметры
            if (!int.TryParse(x, out int xValue) || !int.TryParse(y, out int yValue))
            {
                return Content("NaN", "text/plain");
            }

            // Проверяем, что числа натуральные (> 0)
            if (xValue <= 0 || yValue <= 0)
            {
                return Content("NaN", "text/plain");
            }

            // Вычисляем НОК
            long lcm = CalculateLcm(xValue, yValue);

            // Возвращаем как обычный текст
            return Content(lcm.ToString(), "text/plain");
        }

        private long CalculateLcm(int a, int b)
        {
            // Формула: НОК = |a * b| / НОД(a, b)
            return Math.Abs((long)a * b) / Gcd(a, b);
        }

        private int Gcd(int a, int b)
        {
            // Алгоритм Евклида для НОД
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}


