using Microsoft.AspNetCore.Mvc;

namespace BasicBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Subtract([FromBody] Numbers numbers)
        {
            return numbers.a - numbers.b;
        }
    }

    public class Numbers
    {
        public decimal a { get; set; }
        public decimal b { get; set; }
    }
}
