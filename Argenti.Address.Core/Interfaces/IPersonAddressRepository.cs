using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Argenti.Address.Core.Domain;

namespace Argenti.Address.Core.Interfaces
{
    public interface IPersonAddressRepository
    {
        Task<List<PersonAddressCityGroup>> GetPersonAddressGroupedByCityAsync();
    }
}
