class GradeManager
{
    public List<Student> students = new List<Student> ();

    public void AddStudent()
    {
        Console.Write("Enter the name of the student: ");
        students.Add(new Student { name = Console.ReadLine().Trim() });
    }
    public void AddGradeStudent(double[] grades)
    {
        // show students
        ShowStudents();
        if (students.Count > 0)
        {
            // choose student
            int index;
            Console.Write("Enter the number to the student: ");
            index = Convert.ToInt32(Console.ReadLine());

            if (index >= 0 && index < students.Count)
            {
                // enter grades
                double gradeInput;
                for (int f = 0; f < grades.Length; f++)
                {
                    bool validGrade = false;

                    do
                    {
                        Console.Write($"Enter the {f+1} grade: ");
                        gradeInput = Convert.ToDouble(Console.ReadLine());

                        if (gradeInput >= 0 && gradeInput <= 5)
                        {
                            students[index].Grades[f] = gradeInput;
                            validGrade = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid grade, please type a grade beetween 0.0 and 5.0");
                        }
                    } while (!validGrade);
                    
                }
            }
            else
            {
                Console.WriteLine("*** Number was not found ***");
            }
        }
    }
    public void ShowStudents()
    {
        if (students.Count > 0)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            int index = 0;
            foreach (var fe in students)
            {
                Console.WriteLine($"{index}. Nombre: {fe.name} | Grade: {string.Join(", ", fe.Grades)}");
                index++;
            }
            Console.WriteLine("--------------------------------------------------------------------------");

        }
        else
        {
            Console.WriteLine("*** There are no students ***");
        }
        
    }
    public Student HighestAverage()
    {
        if (students.Count == 0)
        {
            return null;
        }
        else
        {
            Student studentHighestAverage;
            int index = 0;
            double average, temporalAverage = 0;

            for (int f = 0; f < students.Count; f++)
            {
                double sum = 0;

                for (int f1 = 0; f1 < students[f].Grades.Length; f1++)
                {
                    sum = sum + students[f].Grades[f1];
                }
                average = sum / students[f].Grades.Length;

                if (average > temporalAverage)
                {
                    temporalAverage = average;
                    index = f;
                }
            }

            studentHighestAverage = students[index];
            return studentHighestAverage;
        }
    }
}

