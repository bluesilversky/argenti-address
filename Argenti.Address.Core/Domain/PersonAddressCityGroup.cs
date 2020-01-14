using System;
using System.Collections.Generic;
using System.Text;

namespace Argenti.Address.Core.Domain
{
    public class PersonAddressCityGroup
    {
        public string City { get; set; }
        public List<PersonAddress> PersonAddressList { get; set; }
    }
}
