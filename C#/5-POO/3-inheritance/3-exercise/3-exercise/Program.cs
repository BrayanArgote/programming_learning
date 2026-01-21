/* Create a base class Ticket.

Store an id and a creation date.
Require both values when the object is created.

Create a child class ParkingTicket.

Add a vehicle plate number.

Decide which data must be sent to the base constructor. */

class Ticket
{
    public int id { get; }
    
    public DateTime date { get; }

    public Ticket (int id, DateTime date)
    {
        if (id > 0) { this.id = id; }
        else { Console.WriteLine("Invalid id"); }

        if(date != DateTime.MinValue) { this.date = date; }
        else { Console.WriteLine("Invalid date"); }
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine("== DATA ==" +
                          $"\nId: {id} " +
                          $"\nDate: {date}");
    }
}

class ParkingTicket : Ticket
{
    private string vehiclePlate { get; }

    public ParkingTicket(int id, DateTime date, string vehiclePlate) : base(id, date)
    {
        if (vehiclePlate != null) { this.vehiclePlate = vehiclePlate; }
        else
        {
            Console.WriteLine("Invalid plate");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Plate: {vehiclePlate}");
    }

}

class Program
{
    static void Main(string[] args)
    {
        ParkingTicket pt = new ParkingTicket(1, new DateTime(2004,09,04), "ABC-123");

        pt.ShowInfo();
        Console.ReadKey();
    }
}