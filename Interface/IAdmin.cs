using BlueGrassDigital.Models.Admin;
using BlueGrassDigitalAPI.Models.Admin;
using BlueGrassDigitalAPI.Models.Person;

namespace BlueGrassDigitalAPI.Interface
{
    public interface IAdmin
    {
        public Task<PersonDetails> AddPerson(PersonDetails data);
        public Task<PersonEdit> EditPerson(PersonEdit data);
        public Task<ChangedModel> GetChange();

    }
}
