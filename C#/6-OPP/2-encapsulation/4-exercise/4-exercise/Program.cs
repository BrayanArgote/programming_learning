/*
 Create a class that represents a Rectangle.

Width
Height

Width and Height cannot be zero or negative.
Area must NOT be stored as a field.
Area must be calculated automatically.

Area must be accessible using a property, but not editable.
 */

class Rectangle
{
    private double width;
    public double Width
    {
        get { return width; }
        set
        {
            if (value > 0)
            {
                width = value;
            }
        }
    }

    private double height;
    public double Height
    {
        get { return height; }
        set
        {
            if (value > 0)
            {
                height = value;
            }
        }
    }

    public double Area
    {
        get { return width * height; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangleOne = new Rectangle();

        rectangleOne.Height = 2.0;
        rectangleOne.Width = 5.5;
        Console.WriteLine(rectangleOne.Area);

        Console.ReadKey();

    }
}