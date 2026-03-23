namespace APBD_TASK2.Models;

public class Projector : Equipment
{
    public int Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(string name, int resolution, int brightness) : base(name)
        {
            Resolution = resolution;
            Brightness = brightness;
        }
}