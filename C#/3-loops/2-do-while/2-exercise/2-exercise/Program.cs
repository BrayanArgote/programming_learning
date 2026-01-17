/*
 Show a menu to the user.
Menu:
1. Enter numbers
2. Show average
3. Exit

Rules:
The menu must appear at least one time.
The user can enter many numbers.
Option 2 shows the average of entered numbers.
If no numbers exist, print "No data".
The program ends only when the user chooses Exit.
 */

string option;
double sum = 0, amount = 0, number;

do
{
    Console.WriteLine("\n== Menu ==\n" +
                      "1. Enter a Number\n" +
                      "2. Show average\n" +
                      "3. Exit");

    Console.Write("Choose an option: ");
    option = Console.ReadLine();

    if (option != "1" && option != "2" && option != "3")
    {
        Console.WriteLine("Please type a valid option");
        continue;
    }

    if (option == "1")
    {
        Console.Write("Enter the number: ");
        number = Convert.ToDouble(Console.ReadLine());
        amount++;
        sum = sum + number;
    }

    else if (option == "2")
    {

        if (amount == 0)
        {
            Console.WriteLine("No data");
        }

        else
        {
            Console.WriteLine($"The average is: {sum / amount}");
        }
            
    }

} while (option != "3");

Console.ReadKey();
            
    

