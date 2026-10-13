using System;
using Microsoft.AspNetCore.Mvc;

namespace DSALabsWeek01Api.Controllers
{
    // Controllers/LeetCodeController.cs — optional bonus
    [ApiController]
    [Route("api/[controller]")]
    public class LeetCodeController : ControllerBase
    {
        // #7 Reverse Integer
        [HttpGet("reverse/{x}")]
        public IActionResult Reverse(int x)
        {
            long rev = 0;
            long n = Math.Abs((long)x);
            while (n > 0) { rev = rev * 10 + n % 10; n /= 10; }
            rev = x < 0 ? -rev : rev;
            if (rev > int.MaxValue || rev < int.MinValue) return Ok(0);
            return Ok((int)rev);
        }

        // #9 Palindrome Number
        [HttpGet("palindrome/{x}")]
        public IActionResult Palindrome(int x)
        {
            if (x < 0) return Ok(false);
            int original = x; long rev = 0;
            while (x > 0) { rev = rev * 10 + x % 10; x /= 10; }
            return Ok(rev == original);
        }

        public class PowRequest
        {
            public double X { get; set; }
            public int N { get; set; }
        }

        // #50 Pow(x, n)
        [HttpPost("pow")]
        public IActionResult Pow([FromBody] PowRequest req)
        {
            double x = req.X; int n = req.N;
            long N = n;
            if (N < 0) { x = 1 / x; N = -N; }
            double result = 1;
            while (N > 0)
            {
                if ((N & 1) == 1) result *= x;
                x *= x;
                N >>= 1;
            }
            return Ok(result);
        }

        // #509 Fibonacci
        [HttpGet("fib/{n}")]
        public IActionResult Fib(int n)
        {
            if (n < 2) return Ok(n);
            int a = 0, b = 1;
            for (int i = 2; i <= n; i++) { int c = a + b; a = b; b = c; }
            return Ok(b);
        }

        // #172 Factorial Trailing Zeros
        [HttpGet("trailing-zeros/{n}")]
        public IActionResult TrailingZeros(int n)
        {
            int count = 0;
            while (n > 0) { n /= 5; count += n; }
            return Ok(count);
        }
    }
}
