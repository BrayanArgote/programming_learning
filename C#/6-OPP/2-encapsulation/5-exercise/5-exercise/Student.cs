class Student {
    public string name;
    private double[] grades = new double[5];

    public double[] Grades { 
        get { return grades; }

        set
        {
            if (value != null && value.Length == grades.Length)
            {
                grades = value;
            }
            else
            {
                Console.WriteLine("*** Invalid grades ***");
            }
            
        }

    }

    public Student()
    {
        grades = new double[]{ 0, 0, 0, 0, 0 };
    }


    public double CalculateAverage()
    {
        double sum = 0, average;

        for (int f = 0; f < grades.Length; f++)
        {
            sum = sum + grades[f];
        }
        average = sum / grades.Length;
        return average;
            
    }
}
