using EnitityFrameworkCore.Entities;

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
            var filteredFlights = context.Flights
                                        .Where(f => f.ArrivalSity == "Lviv")
                                        .OrderBy(f => f.DepartureTime);
            foreach (var f in filteredFlights)
            {
                Console.WriteLine($"Flight : {f.Id}. From : {f.DepartureSity} " +
                    $"to {f.ArrivalSity}");
            }
            //var client = context.Clients.Find(1);

            //if (client != null)
            //{
            //    context.Clients.Remove(client);
            //    context.SaveChanges();
            //}

            foreach (var f in context.Flights)
            {
                Console.WriteLine($"Flight : {f.Id}, From : {f.DepartureSity}" +
                                        $" to {f.ArrivalSity}");
            }
        }
    }
}
