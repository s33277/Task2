using APBD_TASK2.Database;
using APBD_TASK2.Models;

var db = Singleton.Instance;

var laptop = new Laptop("Dell XPS 15", 2, 13);
db.Equipment.Add(laptop);