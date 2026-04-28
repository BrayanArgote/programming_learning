HashSet<string> attendanceList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
{ "Jose Molina", "Pablo Moreno", "Juana Ortiz", "Gabriel Lopez", "Laura Martinez" };

HashSet<string> presentStudents = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

string presentStudent = "";
 

while (true)
{
    Console.Write("\nEnter the name of a present student or 0 to exit: ");
    presentStudent = Console.ReadLine().Trim();

    if (string.IsNullOrEmpty(presentStudent)) {Console.WriteLine("*** The name can not be empty ***"); continue; }

    if (presentStudent == "0") break;

    if (presentStudents.Add(presentStudent)) Console.WriteLine("-- The student was registered successfully --");
    else Console.WriteLine($"** The student with the name {presentStudent} is already registered **");

}

Console.Clear();

HashSet<string> studentsWhoAttended = new HashSet<string>(attendanceList, StringComparer.OrdinalIgnoreCase);
studentsWhoAttended.IntersectWith(presentStudents);

HashSet<string> unregisteredStudents = new HashSet<string>(presentStudents, StringComparer.OrdinalIgnoreCase);
unregisteredStudents.ExceptWith(attendanceList);

Console.WriteLine(new string('-', 35));
Console.WriteLine($"| ATTENDANCE TRACKING {DateTime.Today.ToString("dd/MM/yyyy")} |");
Console.WriteLine(new string('-', 35));
Console.WriteLine("| {0, -15} | {1, -13} |", "NAME", "IS PRESENT?");
Console.WriteLine(new string('-', 35));

foreach(var student in attendanceList)
{
    bool isPresent = studentsWhoAttended.Contains(student);
    Console.WriteLine("| {0, -15} | {1, -13} |", student, isPresent ? "YES" : "NO");
    Console.WriteLine(new string('-', 35));
}

if (unregisteredStudents.Count() > 0)
{

    Console.WriteLine(new string('-', 36));
    Console.WriteLine($"| UNREGISTERED STUDENTS {DateTime.Today.ToString("dd/MM/yyyy")} |");
    Console.WriteLine(new string('-', 36));

    foreach (var student in unregisteredStudents)
    {
        Console.WriteLine("| {0, -32} |", student);
        Console.WriteLine(new string('-', 36));
    }
}

Console.ReadKey();