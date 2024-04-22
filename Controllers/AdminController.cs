using BlueGrassDigital.Models.Admin;
using BlueGrassDigitalAPI.Interface;
using BlueGrassDigitalAPI.Models.Admin;
using BlueGrassDigitalAPI.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace BlueGrassDigitalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin Admin)
        {
            _admin = Admin;
        }



        [HttpPost]
        [Route("Add_Person")]
        public async Task<PersonDetails> AddPerson(PersonDetails data)
        {
            return await _admin.AddPerson(data);

        }


        [HttpPost]
        [Route("Edit_Person")]
        public async Task<PersonEdit> EditPerson(PersonEdit data)
        {
            return await _admin.EditPerson(data);

        }

        [HttpGet]
        [Route("Get_Change")]
        public async Task<ChangedModel> GetChange()
        {
            return await _admin.GetChange();

        }
    }
}
