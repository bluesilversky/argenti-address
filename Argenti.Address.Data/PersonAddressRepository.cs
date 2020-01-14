using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Argenti.Address.Core.Interfaces;
using Argenti.Address.Core.Domain;


namespace Argenti.Address.Data
{
    public class PersonAddressRepository : IPersonAddressRepository
    {
        public string DataFilePath { get; }

        public PersonAddressRepository(string dataFilePath)
        {
            DataFilePath = dataFilePath;
        }
        
        public async Task<List<PersonAddressCityGroup>> GetPersonAddressGroupedByCityAsync()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            
            PersonAddressRoot root;
            using (FileStream stream = File.OpenRead(DataFilePath))
            {
                root = await JsonSerializer.DeserializeAsync<PersonAddressRoot>(stream, options);
            }

            var textInfo = CultureInfo.CurrentUICulture.TextInfo;

            var results = root.PersonAddressList
                .GroupBy(pa => textInfo.ToTitleCase(pa.City))
                .Select(grp => new PersonAddressCityGroup()
                {
                    City = grp.Key,
                    PersonAddressList = grp.ToList()
                })
                .OrderBy(grp => grp.City)
                .ToList();

            return results;
        }
    }
}
