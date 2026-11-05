namespace TableBooking;

public sealed class FridayNightBooking
{
    private object _Lock { get; } = new object();
	public int TablesLeft { get; private set; } = 5;
    public int Booked { get; private set; }

    public void Book(string customerName)
    {
        lock (_Lock)
        {
            if (TablesLeft <= 0)
                return;

             Thread.Sleep(20);
            TablesLeft--;
            Booked++;
            Console.WriteLine($"{customerName} booked a table. Left={TablesLeft}");
        }
    }
}
