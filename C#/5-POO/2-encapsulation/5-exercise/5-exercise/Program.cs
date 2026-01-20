/* Classes:

Student
GradeManager

Student stores name and grades.
Grades are private.
GradeManager works with a list of students.

The program must:

Add students using GradeManager.
Add grades to a student.
Calculate average.
Find the student with the highest average.
*/

class Programs
{
    static void Main(string[] args)
    {
        GradeManager gradeManager = new GradeManager();
        Student student = new Student();

        int option;
        do
        {
            Console.WriteLine("\n1. Add student. " +
                              "\n2. Add grades to student. " +
                              "\n3. Show students. " +
                              "\n4. Calculate average to a student. " +
                              "\n5. Show the student with the highest average. " +
                              "\n6. Exit. ");
            Console.Write("Enter an option: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    gradeManager.AddStudent();
                    break;

                case 2:
                    gradeManager.AddGradeStudent(gradeManager.students.Grades); // CORREGIR ESTE METODO, EL INDICE SE DA ACA 
                    break;

                case 3:
                    gradeManager.ShowStudents();
                    break;

                case 4:
                    gradeManager.ShowStudents();
                    if(gradeManager.students.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Enter the number of the student: ");
                        int index = Convert.ToInt32(Console.ReadLine());

                        if (index >= 0 && index < gradeManager.students.Count)
                        {
                            student = gradeManager.students[index];
                            Console.WriteLine($"The student {student.name} has an average of {student.CalculateAverage()}");

                        }
                        else
                        {
                            Console.WriteLine("*** Student was not found ***");
                        }
                        break;
                    }
                        
                case 5:
                    if (gradeManager.HighestAverage() == null)
                    {
                        Console.WriteLine("*** There are no students ***");
                    }
                    else
                    {
                        Console.WriteLine($"The student with the hihgest average is: {gradeManager.HighestAverage().name}");
                    }
                    break;

                case 6: Console.WriteLine("Exiting..."); break;

                default:
                    Console.WriteLine("*** Invalid Option ***");
                    break;
            }

        } while (option != 6);


        Console.ReadKey();
    }
}


/* SEVERAL MISTAKES
 
 * i did not use encapsulation for all attributes.
 * wrong words or sentence in english.
 * i mixed console input and output inside methods.
 
 */
 