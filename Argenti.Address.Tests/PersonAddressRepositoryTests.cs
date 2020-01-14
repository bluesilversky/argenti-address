using NUnit.Framework;
using Argenti.Address.Core.Interfaces;
using Argenti.Address.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Argenti.Address.Tests
{
    public class PersonAddressRepositoryTests
    {
        private const string _addressJsonFilePath = "../../../../Argenti.Address.Data/AddressData.json";
        private IPersonAddressRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new PersonAddressRepository(_addressJsonFilePath);
        }

        [Test]
        public async Task RepositoryGroupsTo3Cities()
        {
            var result = await _repository.GetPersonAddressGroupedByCityAsync();
            
            //get the distinct list of cities from the whole data set.
            var cities = result.SelectMany(grp => grp.PersonAddressList.Select(list => list.City.ToUpperInvariant())).Distinct();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(3, cities.Count());
        }
    }
}