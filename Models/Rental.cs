namespace APBD_TASK2.Models;

public class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public decimal CalculatePenalty()
    {
        if (!ReturnDate.HasValue | ReturnDate <= DueDate) return 0;
        TimeSpan delay = ReturnDate.Value - DueDate;
        return delay.Days*4;
    }
}