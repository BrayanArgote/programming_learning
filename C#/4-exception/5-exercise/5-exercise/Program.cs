/*
Create a "file" variable.
Try to open it.
Catch an error if the file does not exist.
Use finally to always print “Shutting down the program”.
*/

FileStream file = null;
string inputFile;

Console.Write("Enter the file's name: ");
inputFile = Console.ReadLine();

try
{
    file = new FileStream(inputFile, FileMode.Open);
}

catch (FileNotFoundException)
{
    Console.WriteLine($"*** The file with the name *{inputFile}* doesn't exists ***");
}
finally
{
    Console.WriteLine("\n--- Shutting down the program ---");
    file.Close();
}


Console.ReadKey();