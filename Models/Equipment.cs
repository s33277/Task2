using APBD_TASK2.Enum;

namespace APBD_TASK2.Models
{
    public class Equipment
    {
        public static int _nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
        public string Description { get; set; } = null!;

        public DateTime AddedDate { get; set; }

        public Equipment(string name, string description = "")
        {
            Id = _nextId++;
            Name = name;
            Description = description;
            AddedDate = DateTime.Now;
        }
    }
}