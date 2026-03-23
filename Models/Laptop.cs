namespace APBD_TASK2.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public int ScreenSize { get; set; }

    public Laptop(string name, int ramGb, int screenSize) : base(name)
    {
        RamGb = ramGb;
        ScreenSize = screenSize;
    }
}