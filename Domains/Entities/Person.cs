using PhoneBook.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PhoneBook.Domains.Entities
{
    public class Person : BaseEntity<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PersonPhoneBookStatus Status { get; set; }
    }
}
