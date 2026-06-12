using PhoneBook.Domains.Entities;
using PhoneBook.Services;
namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBookService = new PhoneBookService();

            var exitOption = "-1";


            while(true)
            {
                Console.WriteLine("Please Select an Option: ");
                Console.WriteLine("1 - Enter a New Phone Book Person.");
                Console.WriteLine("2 - Search for an entry by name.");
                Console.WriteLine("3 - Search for an entry by phone number.");
                Console.WriteLine("4 - Get all entries in the phone book.");
                Console.WriteLine("5 - Delete an entry from the phone book.");
                Console.WriteLine("6 - Enter -1 to Exit from the application.");

                var selectionOption = Console.ReadLine();

                if (selectionOption == exitOption)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (selectionOption == "1")
                {
                    Console.Write("Name : ");
                    var name = Console.ReadLine();
                    Console.Write("PhoneNumber: ");
                    var phoneNumber = Console.ReadLine();

                    var person = new Person()
                    {

                        Name = name,
                        PhoneNumber = phoneNumber,

                    };

                    phoneBookService.AddEntry(person);



                }
                else if (selectionOption == "2")
                {
                    try
                    {
                        Console.Write("Enter Name To search about it : ");
                        var name = Console.ReadLine();

                        var results = phoneBookService.SearchByName(name);

                        foreach (var result in results)
                        {
                            Console.WriteLine($"Name: {result.Name}");
                            Console.WriteLine($"Phone Number: {result.PhoneNumber}");
                            Console.WriteLine("------------------------------------------");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (selectionOption == "3")
                {
                    try
                    {
                        Console.Write("Enter Phone Number To search about it : ");
                        var phoneNumber = Console.ReadLine();

                        var results = phoneBookService.SearchByPhoneNumber(phoneNumber);

                        foreach (var result in results)
                        {
                            Console.WriteLine($"Name: {result.Name}");
                            Console.WriteLine($"Phone Number: {result.PhoneNumber}");
                            Console.WriteLine("------------------------------------------");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (selectionOption == "4")
                {
                    try
                    {
                        Console.WriteLine("All Entries in the Phone Book:");

                        var allEntries = phoneBookService.GetAll();

                        foreach (var entry in allEntries)
                        {
                            Console.WriteLine($"Phone Id: {entry.Id}");
                            Console.WriteLine($"Name: {entry.Name}");
                            Console.WriteLine($"Phone Number: {entry.PhoneNumber}");
                            Console.WriteLine("------------------------------------------");

                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else if (selectionOption == "5")
                {
                    try
                    {
                        Console.Write("Enter Phone Number To delete the entry : ");
                        int phoneNumber = int.Parse(Console.ReadLine());
                        phoneBookService.DeleteEntry(phoneNumber);
                        Console.WriteLine("Entry deleted successfully.");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine("Invailed Option");
                }

                Console.WriteLine("-------------------------------------------------");
            }



        }
    }
}
