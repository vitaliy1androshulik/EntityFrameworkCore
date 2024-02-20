using EnitityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnitityFrameworkCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDBContext context = new AirplaneDBContext();
            context.Clients.Add(new Client()
            {
                Name = "Volodya",
                Birthday = new DateTime(2006, 7, 12),
                Email = "volodya@gmail.com"
            });
            context.SaveChanges();
            //foreach (var item in context.Clients)
            //{
            //    Console.WriteLine($"Client : name - {item.Name}, email - " +
            //        $"{item.Email}, birthday - {item.Birthday?.ToShortDateString()}");
            //}



            //Loading data : Include(relation data)
            var filteredFlights = context.Flights
                                        .Include(f=>f.Airplane)
                                        .Where(f => f.ArrivalSity == "Lviv")
                                        .OrderBy(f => f.DepartureTime);
            foreach (var f in filteredFlights)
            {
                Console.WriteLine($"Flight : {f.Id}. From : {f.DepartureSity, -10} " +
                    $"to {f.ArrivalSity}" +
                    $" Airplane : {f.AirplaneId} - {f.Airplane?.Model}" +
                    $" Count Pass : {f.Airplane?.MaxPassengers}");
            }
            //Explicit data loading : context.Entry(entity).Collection/Reference()
            var client = context.Clients.Find(2);
            context.Entry(client).Collection(c=>c.Flights).Load();
            Console.WriteLine($"Client : {client.Name} ." +
                $" Count flights : {client.Flights.Count}");

            foreach(var f in client.Flights)
            {
                Console.WriteLine($"{f.DepartureSity}{f.ArrivalSity}");
            }

            //var client = context.Clients.Find(1);

            //if (client != null)
            //{
            //    context.Clients.Remove(client);
            //    context.SaveChanges();
            //}

            //foreach (var f in context.Flights)
            //{
            //    Console.WriteLine($"Flight : {f.Id}, From : {f.DepartureSity}" +
            //                            $" to {f.ArrivalSity}");
            //}
        }
    }
}
