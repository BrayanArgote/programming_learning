/*
Ask the user for a password.
If the password has less than 6 characters, throw an exception.
Catch it and show the error message.
*/

using System.ComponentModel.DataAnnotations;

string password;
Console.Write("Enter a password: ");
password = Console.ReadLine().Trim();

try
{
    if(password.Length < 6)
    {
        throw new Exception("*** Password must be at least 6 characters long ***");
    }

    Console.WriteLine("--- Valid password ----");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadKey();