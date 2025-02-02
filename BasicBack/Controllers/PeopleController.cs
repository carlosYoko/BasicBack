using BasicBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
        }

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var person = Repository.People.FirstOrDefault(p => p.Id == id)!;

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search)
        {
            return Repository.People.Where(p => p.Name!.ToUpper().Contains(search.ToUpper())).ToList();
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people)) return BadRequest("Name is required");
            people.Id = Repository.People.Count() + 1;
            Repository.People.Add(people);

            return NoContent();
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
        public string? Name { get; set; }
        public DateTime BDay { get; set; }
    }
}