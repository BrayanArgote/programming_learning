/*
 Ask the user to enter a password.

Rules:
The correct password is "admin123".
The user must try at least one time.

After each try:
If the password is wrong, print "Wrong password".
If the password is correct:
Print "Access granted".

Stop the loop.
The user has a maximum of 3 tries.
If all tries are used, print "Access blocked". 
 */

string password;
int attempts = 0;

do
{
    Console.Write("Enter your password: ");
    password = Console.ReadLine();
    attempts++;

    if (attempts >= 3)
    {
        Console.WriteLine("Access blocked");
        break;
    }

    if (password == "admin123")
    {
        Console.WriteLine("Access granted");
        break;
    }
    else
    {
        Console.WriteLine("Wrong password");
    }

}while (true);
