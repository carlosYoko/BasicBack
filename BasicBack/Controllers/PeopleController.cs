using Microsoft.AspNetCore.Mvc;

namespace BasicBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People { Id = 1, Name = "John", BDay = new DateTime(1990, 1, 1) },
            new People { Id = 2, Name = "Jane", BDay = new DateTime(1991, 2, 2) },
            new People { Id = 3, Name = "Jack", BDay = new DateTime(1992, 3, 3) }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BDay { get; set; }
    }
}