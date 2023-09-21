using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firstwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/Add?a=10&b=2;
        [HttpGet("Calculator/Add")]
        public int Add(int a ,int b)
        {
            return a+b;
        }
        //api/calculator/Subtract? a = 10 & b = 2;
        [HttpGet("Calculator/Sum")]
        public int Sum(int a, int b)
        {
            return a + b+1000;
        }
        [HttpPost]
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        //api/calculator/Multiply?a=10&b=2;

        [HttpPut]
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        //api/calculator/Divide?=10&b=2;
       
        [HttpDelete]
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
