using APBD_TASK2.Config;
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
            
            int userActiveCount = GetActiveRentals().Count(r => r.User.Id == user.Id);
            if (userActiveCount >= user.MaxActiveRentals)
                throw new Exception("Limit exceeded.");

            equipment.Status = EquipmentStatus.Rented;
            Rental rental = new Rental
            {
                User = user,
                Equipment = equipment,
                RentalDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(Constants.StandardRentalDays)
            };
            Singleton.Instance.Rentals.Add(rental);
        }

        public decimal ReturnEquipment(Equipment equipment)
        {
            var rental = GetAllRentals().FirstOrDefault(r => r.Equipment.Id == equipment.Id && r.ReturnDate == null);
            if (rental == null) throw new Exception("No active rental found for this equipment.");
            rental.ReturnDate = DateTime.Now;
            equipment.Status = EquipmentStatus.Available;
            return rental.CalculatePenalty();
        }

        public void GenerateReport()
        {
            Console.WriteLine("======= RENTAL REPORT =======");
            Console.WriteLine("Total items: " + GetAllEquipment().Count);
            Console.WriteLine("Items available: "+GetAllEquipment().Count(e => e.Status == EquipmentStatus.Available));
            Console.WriteLine("Active rentals: "+GetActiveRentals().Count);
            foreach (Rental r in GetActiveRentals())
            {
                Console.WriteLine(r.User.FirstName + " " + r.User.LastName + ": " + r.Equipment.Name + " till " + r.DueDate);
            }
            Console.WriteLine("Overdue rentals: " + GetAllRentals().Count(r => r.IsOverdue));
            var overdueRentals = GetAllRentals().Where(r => r.IsOverdue).ToList();
            if (overdueRentals.Count == 0)
            {
                Console.WriteLine("No overdue rentals found.");
            }
            else
            {
                foreach (Rental r in overdueRentals)
                {
                    Console.WriteLine(r.User.FirstName + " " + r.User.LastName + ": " + r.Equipment.Name + " delay: " + r.CalculateLateDays() + " days");
                }
            }
        }

        public List<Equipment> GetAllEquipment()
        {
            return Singleton.Instance.Equipment;
        }

        public List<Equipment> GetAvailableEquipment()
        {
            return GetAllEquipment().Where(e => e.Status == EquipmentStatus.Available).ToList();
        }

        public List<Rental> GetAllRentals()
        {
            return Singleton.Instance.Rentals;
        }

        public List<Rental> GetActiveRentals()
        {
            return GetAllRentals().Where(r => r.ReturnDate == null).ToList();
        }
    }
}

