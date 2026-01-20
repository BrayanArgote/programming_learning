/*
Create a class Student.
Add a method Average(int[] scores) that returns the average of the scores.
Add another method GetGrade(int average) that returns a string with the grade:

- A if 90 or more
- B if 80–89
- C if 70–79
- D if 60–69
- F if less than 60

Test these methods in Main.
 */

class Student
{
    double Average(int[] scores)
    {
        double average;
        int sum = 0;

        foreach (int n in scores)
        {
            sum = sum + n;
        }

        average = (double)sum / scores.Length;
        return average;
    }

    string GetGrade(double average)
    {

        string grade = (average) switch
        {
            >= 90 and <=100 => "A",
            >= 80           => "B",
            >= 70           => "C",
            >= 60           => "D",
            >= 0 and < 60   => "F",
            _               => "Invalid grade",

        };

        return grade;
    }


    static void Main(string[] args)
    {
        Student StudentOne = new Student();
        Console.WriteLine("The avera is: " + StudentOne.Average(new int[] {90, 40, 91}));
        Console.WriteLine("The grade is: " + StudentOne.GetGrade( StudentOne.Average([90, 40, 91]) ));

        Console.ReadKey();
    }
}
