using APBD_TASK2.Models;
using APBD_TASK2.Enum;
using APBD_TASK2.Database;

var service = new RentalService();

var student = new User("Anastasiia", "Tumka", "s33277@pjwstk.edu.pl", UserType.Student);
var employee = new User("Jakub", "Biniek", "jakubbiniek@pjwstk.edu.pl", UserType.Employee);
service.AddUser(student);
service.AddUser(employee);

var laptop1 = new Laptop("Dell XPS", 16, 13);
var laptop2 = new Laptop("MacBook Pro", 32, 14);
var camera = new Camera("Sony A7", 1080, "Full Frame");
var projector = new Projector("Epson EB-L", 1080, 5000);

service.AddEquipment(laptop1);
service.AddEquipment(laptop2);
service.AddEquipment(camera);
service.AddEquipment(projector);

Console.WriteLine("======= Student =======");
try 
{
    service.RentEquipment(student, laptop1);
    Console.WriteLine($"Rented {laptop1.Name} to {student.FirstName}");
    
    service.RentEquipment(student, laptop2);
    Console.WriteLine($"Rented {laptop2.Name} to {student.FirstName}");
    
    Console.WriteLine("Attempting 3rd rental for student");
    service.RentEquipment(student, camera);
} 
catch (Exception ex) 
{
    Console.WriteLine($"Blocked: {ex.Message}");
}


Console.WriteLine("\n======= Projector =======");
try 
{
    service.RentEquipment(employee, projector);
    Console.WriteLine($"Rented {projector.Name} (Brightness: {projector.Brightness}) to {employee.FirstName}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\n======= Late Return Penalty =======");
var lateLaptop = new Laptop("Old ThinkPad", 8, 15);
service.AddEquipment(lateLaptop);

var lateRental = new Rental {
    User = employee,
    Equipment = lateLaptop,
    RentalDate = DateTime.Now.AddDays(-15),
    DueDate = DateTime.Now.AddDays(-5)
};
Singleton.Instance.Rentals.Add(lateRental);
lateLaptop.Status = EquipmentStatus.Rented;


decimal penalty = service.ReturnEquipment(lateLaptop);
Console.WriteLine($"Returned {lateLaptop.Name}. Late penalty: {penalty}");


service.GenerateReport();