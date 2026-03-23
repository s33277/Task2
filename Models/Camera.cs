namespace APBD_TASK2.Models
{
    public class Camera : Equipment
    {
        public string SensorType { get; set; }
        public int Resolution { get; set; }
        
        public Camera (string name, int resolution, string sensorType) : base(name)
        {
            Resolution = resolution;
            SensorType = sensorType;
        }
    }
}