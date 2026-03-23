namespace APBD_TASK2.Models;

public class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public bool IsOverdue => !ReturnDate.HasValue && DateTime.Now > DueDate;

    public decimal CalculatePenalty()
    {
        if (!ReturnDate.HasValue || ReturnDate <= DueDate) return 0;
        int lateDays = (ReturnDate.Value - DueDate).Days;
        return lateDays*4m;
    }
    public int CalculateLateDays() => ReturnDate.HasValue ? (ReturnDate.Value - DueDate).Days : 0;
}