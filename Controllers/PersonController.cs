using BlueGrassDigitalAPI.Interface;
using BlueGrassDigitalAPI.Logic;
using BlueGrassDigitalAPI.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace BlueGrassDigitalAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _person;

        public PersonController(IPerson Person)
        {
            _person = Person;
        }



        [HttpGet]
        [Route("Get_Person")]
        public async Task<List<PersonResponse>> GetPerson()
        {
            return await _person.GetAllPerson();
          
        }
    }
}
