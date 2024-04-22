using BlueGrassDigital.Models.Admin;
using BlueGrassDigitalAPI.Interface;
using BlueGrassDigitalAPI.Models.Admin;
using BlueGrassDigitalAPI.Models.Person;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlueGrassDigitalAPI.Logic
{
    public class Admin : IAdmin
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly IPerson _person;

        public Admin(IPerson Person)
        {
            _person = Person;   
        }


            public async Task<PersonDetails> AddPerson(PersonDetails data)
             {   
            try
            {

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/PostProducts"),
                    Content = content   
                };
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON to a single PokemonImages object
                PersonDetails people = JsonConvert.DeserializeObject<PersonDetails>(body);

                return people;

            }
            catch (Exception ex)
            {
                throw;
            }


            }


        public async Task<PersonEdit> EditPerson(PersonEdit data)
        {
            try
            {
            
                List<PersonResponse> personResponses = await _person.GetAllPerson();
                PersonResponse originalPerson = personResponses.FirstOrDefault(x => x._id.Oid == data.todo_id);

             
                List<string> changedProperties = GetChangedProperties(originalPerson, data);

               
                ChangedModel changed = new ChangedModel
                {
                    Original = originalPerson,
                    Changed = data,
                    ChangedProperties = changedProperties
                };

             
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/EditProduct"),
                    Content = content
                };
                using var response = await _httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

               
                PersonEdit updatedPerson = JsonConvert.DeserializeObject<PersonEdit>(responseBody);

              
                await addChangedAsync(changed);

                return updatedPerson;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<string> GetChangedProperties(PersonResponse original, PersonEdit changed)
        {
            List<string> changes = new List<string>();

            if (original.FirstName != changed.FirstName)
                changes.Add("FirstName");

            if (original.LastName != changed.LastName)
                changes.Add("LastName");

            if (original.AddressCountry != changed.AddressCountry)
                changes.Add("AddressCountry");

            if (original.AddressCity != changed.AddressCity)
                changes.Add("AddressCity");

            if (original.MobileNumber != changed.MobileNumber)
                changes.Add("MobileNumber");

            if (original.Email != changed.Email)
                changes.Add("Email");

            if (original.Gender != changed.Gender)
                changes.Add("Gender");

            return changes;
        }

        private async Task addChangedAsync(ChangedModel changed)
        {
            try
            {

                string json = JsonConvert.SerializeObject(changed, Formatting.Indented);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/PostEdited"),
                    Content = content
                };
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ChangedModel> GetChange()
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://us-east-1.aws.webhooks.mongodb-realm.com/api/client/v2.0/app/testing-skqpg/service/myProfileApi/incoming_webhook/GetEdited")
                };
                using var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON to a single PokemonImages object
                ChangedModel people = JsonConvert.DeserializeObject<ChangedModel>(body);

                return people;

            }
            catch (Exception ex)
            {
                throw;
            }


        }

    }
}
