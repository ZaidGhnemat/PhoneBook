using PhoneBook.Domains.Entities;
using PhoneBook.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBook
    {
        #region Variables
        private readonly List<Person> _phoneBookEntries;
        #endregion

        #region Constructors
        public PhoneBookService()
        {
            if (_phoneBookEntries is null)
            {
                _phoneBookEntries = new List<Person>();
            }
        }
        #endregion


        #region Public Methods
        /// <summary>
        ///     Add a new entry to the phone book. If an entry with the same name or phone number already exists, it should not be added and an appropriate message should be returned.
        /// </summary>
        /// <param name="person">Add a new person to the phone book person</param>
        public void AddEntry(Person person)
        {
            try
            {
                if(person == null)
                    throw new ArgumentNullException(nameof(person), "Person cannot be null.");

                person.Id = GenerateUniqueId();
                _phoneBookEntries.Add(person);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///    Delete an entry from the phone book by its unique identifier. If the entry does not exist, an appropriate message should be returned.
        /// </summary>
        /// <param name="id">Delete an person from the phone book</param>
        public void DeleteEntry(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException("this record did not define", nameof(id));
                }

                var personToDelete = _phoneBookEntries.Where(q => q.Id == id).FirstOrDefault();

                if (personToDelete != null)
                {
                    _phoneBookEntries.Remove(personToDelete);
                }
                else
                {
                    throw new KeyNotFoundException($"No entry found with id :  {id}.");
                }


             }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get all entries in the phone book. The entries should be returned in a list format, and each entry should include the person's name, phone number, and status (active or inactive).
        /// </summary>
        /// <returns>Get all Person entries in the phone book</returns>
        public List<Person> GetAll()
        {
            try
            {
                var persons = _phoneBookEntries.Select(q => new Person
                {
                    Id = q.Id,
                    Name = q.Name,
                    PhoneNumber = q.PhoneNumber
                }).ToList();

                if(persons == null)
                    throw new InvalidOperationException("No entries found in the phone book.");

                return persons;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        ///  search for entries in the phone book by name. The search should be case-insensitive and should return all entries that contain the search term in their name.
        /// </summary>
        /// <param name="name">search for entries in the phone book by name</param>
        /// <returns></returns>
        public List<Person> SearchByName(string name)
        {
            try
            {
                return SearchByData(name, p => p.Name);
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// search for entries in the phone book by phone number. The search should return all entries that contain the search term in their phone number.
        /// </summary>
        /// <param name="phoneNumber">search for entries in the phone book by phone number</param>
        /// <returns></returns>
        public List<Person> SearchByPhoneNumber(string phoneNumber)
        {
            try
            {
                return SearchByData(phoneNumber, p => p.PhoneNumber);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region Private Methods

        private List<Person> SearchByData(string searchTerm, Func<Person, string> selector)
        {
            var results = _phoneBookEntries
                .Where(q => selector(q).Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //if (!results.Any())
            //    throw new KeyNotFoundException($"No entries found containing: {searchTerm}");

            return results;
        }

        private int GenerateUniqueId()
        {
            return _phoneBookEntries.Count > 0 ? _phoneBookEntries.Max(q => q.Id) + 1 : 1;
        }

        #endregion

    }
}
