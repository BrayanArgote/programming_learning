using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Queries q = new Queries();
        string option = "";

        do
        {
            Console.WriteLine("\n=========== MENU ===========" +
                              "\n1. List customers records." +
                              "\n2. List products records." +
                              "\n3. Search producr by id." +
                              "\n4. Add customers." +
                              "\n5. Delete Sale." +
                              "\n6. Exit.");
            Console.Write("Enter an Option: ");
            option = Console.ReadLine();

            switch(option){
                case "1": q.GetAllCustomers(); break;
                case "2": q.GetAllProducts(); break;
                case "3": 
                    Console.Write("Enter the id: ");

                    int id;
                    if(!int.TryParse(Console.ReadLine(), out id)){
                        Console.WriteLine("*** Invalid id ***");
                    }
                    else
                    {
                        q.GetProductById(id);
                    }
                    break;
                case "4":

                    string name, address, phone_number;

                    Console.Write("Enter a name: ");
                    name = Console.ReadLine().Trim(); 
                    Console.Write("Enter a address: ");
                    address = Console.ReadLine().Trim();
                    Console.Write("Enter a phone number: ");
                    phone_number = Console.ReadLine().Trim();

                    if (name.IsNullOrEmpty() && address.IsNullOrEmpty() && phone_number.IsNullOrEmpty())
                    {
                        Console.WriteLine("--- Invalid data ---");
                    }
                    else
                    {
                        q.AddCustomer(name, address, phone_number);
                    }
                    break;

                case "5":
                    int idSale;
                    Console.Write("Enter the id: ");

                    if(int.TryParse(Console.ReadLine(), out idSale))
                    {
                        q.DeleteSale(idSale);
                    }
                    else
                    {
                        Console.WriteLine("*** Please type a valid id (integer number) ***");
                    }
                        break;

                case "6": Console.WriteLine("Exiting..."); ; break;
                        default: Console.WriteLine("*** Please type a valid option ***"); break;
                        }
        } while (option != "6");

        Console.ReadKey();
    }

}