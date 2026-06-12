using PhoneBook.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domains.Interfaces
{
    public interface IPhoneBook
    {
        void AddEntry(Person person);
        List<Person> SearchByName(string name);
        List<Person> SearchByPhoneNumber(string phoneNumber);
        List<Person> GetAll();

        void DeleteEntry(int id);
    }
}
