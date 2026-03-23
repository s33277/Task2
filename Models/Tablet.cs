namespace APBD_TASK2.Models
{
    public class Tablet : Equipment
    {
        public bool HasStylus { get; set; }
        public string OperatingSystem { get; set; }

        public Tablet(string name, bool hasStylus, string os) 
            : base(name)
        {
            HasStylus = hasStylus;
            OperatingSystem = os;
        }
    }
}