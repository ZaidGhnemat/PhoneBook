using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domains.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
