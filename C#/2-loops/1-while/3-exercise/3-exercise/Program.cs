/*
The program has a secret letter (a vowel).
Ask the user to guess letters.
If the guess is consonat, print "Try again" and continue.
If the guess is a vowel but is not the correct letter, print "You are close"
If the guess is not a letter, print "Invalid character"
If the guess is correct, print "Correct" and break.
Limit guesses to 10 attempts, then print "Game over" if not guessed.
 */

char letter;
int atemps = 0;


while (true)
{

    if (atemps >= 10)
    {
        Console.WriteLine("Game Over");
        break;
    } 

    Console.Write("Enter a letter: ");
    atemps++;

    if (!char.TryParse(Console.ReadLine(), out letter))
    {
        Console.WriteLine("Please type one character");
        continue;
    }

    else if (letter == 'i')
    {
        Console.WriteLine("Correct");
        break;
    }

    else if (letter == 'a' || letter == 'e' || letter == 'o' || letter == 'u' ||
             letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U')
    {
        Console.WriteLine("You are close");
    }

    else if (char.IsLetter(letter))
    {
        Console.WriteLine("Try again");
    }
    else
    {
        Console.WriteLine("Inavalid character");
    }
}

Console.ReadKey();


