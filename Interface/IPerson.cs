using BlueGrassDigitalAPI.Logic;
using BlueGrassDigitalAPI.Models.Person;

namespace BlueGrassDigitalAPI.Interface
{
    public interface IPerson
    {

        public Task<List<PersonResponse>> GetAllPerson();
    }
}
