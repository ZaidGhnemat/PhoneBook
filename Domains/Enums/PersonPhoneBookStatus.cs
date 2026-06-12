using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace PhoneBook.Domains.Enums
{
    public enum PersonPhoneBookStatus
    {
        None = 0,
        Active = 1,
        Pending = 2,
        Inactive = 3,
        Deleted = 4
    }
}
