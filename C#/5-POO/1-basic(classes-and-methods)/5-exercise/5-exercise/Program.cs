/*
Create a class Student with attributes name and scores (a list of int).
Create a constructor that receives name and scores and saves them.
Add a method Average() that returns the average of the scores.
In Main, create 2 students and print their name and average.
 */

class Student
{
    string name;
    List<int> scores;

    Student (string n, List<int> s)
    {
        name = n;
        scores = s;
    }

    double Average ()
    {
        double sum = 0, average;

        foreach (int f in scores)
        {
            sum += f;
        }

        average = sum / scores.Count;
        return average;
    }

    static void Main(string[] args)
    {
        Student studentOne = new Student("Juan", new List<int>{3, 2, 4});
        Student studentTwo = new Student("Juana", new List<int> {4, 4, 4 });

        Console.WriteLine($"Student name: {studentOne.name} \nAverage: {studentOne.Average()}");
        Console.WriteLine($"Student name: {studentTwo.name} \nAverage: {studentTwo.Average()}");

        Console.ReadKey();
    }

}
