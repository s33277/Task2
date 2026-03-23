using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Models
{
    public class RentalService : IRentalService
    {
        public void AddUser(User user)
        {
            Singleton.Instance.Users.Add(user);
        }

        public void AddEquipment(Equipment equipment)
        {
            Singleton.Instance.Equipment.Add(equipment);
        }

        public void RentEquipment(User user, Equipment equipment)
        {
            if (equipment.Status != EquipmentStatus.Available)
                throw new Exception("Equipment is not available.");
            
            if (Singleton.Instance.Rentals.Count >= user.MaxActiveRentals)
                throw new Exception("Limit exceeded.");

            equipment.Status = EquipmentStatus.Rented;
            Rental rental = new Rental();
            Singleton.Instance.Rentals.Add(rental);
        }

        public decimal ReturnEquipment(Equipment equipment)
        {
            var rental = Singleton.Instance.Rentals.FirstOrDefault(r => r.Equipment.Id == equipment.Id && r.ReturnDate == null);
            if (rental == null) throw new Exception("No active rental found for this equipment.");
            rental.ReturnDate = DateTime.Now;
            equipment.Status = EquipmentStatus.Available;
            return rental.CalculatePenalty();
        }

        public List<Equipment> GetAllEquipment()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAvailableEquipment()
        {
            throw new NotImplementedException();
        }
    }
}

