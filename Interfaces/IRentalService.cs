using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalService
    {
        void AddUser(User user);
        void AddEquipment(Equipment equipment);

        public void RentEquipment(User user, Equipment equipment);
        public decimal ReturnEquipment(Equipment equipment);

        List<Equipment> GetAllEquipment();
        List<Equipment> GetAvailableEquipment();
        public List<Rental> GetAllRentals();
        public List<Rental> GetActiveRentals();

    }
}

