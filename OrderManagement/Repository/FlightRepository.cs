using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OrderManagement.DomainModel;
using System.Linq;

namespace OrderManagement.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly string _fileName = "flights.json";
        private List<Flight> originalFlights;

        public async Task<IEnumerable<Flight>> GetFlightsByDestination(string destination, CancellationToken cancellationToken)
        {
            if (originalFlights == null)
            {
                throw new Exception("Flights are not loaded");
            }
            return originalFlights.Where(x => x.Destination == destination && x.Aircraft.Capacity > x.UsedSpace)
               .OrderBy(x => x.DepartureDate);
        }

        public async Task<IEnumerable<Flight>> GetFlights(CancellationToken cancellationToken)
        {
            if (originalFlights == null)
            {
                throw new Exception("Flights are not loaded");
            }
            return originalFlights.OrderBy(x => x.DepartureDate);
        }

        public async Task LoadFlights(CancellationToken cancellationToken)
        {

            try
            {
                originalFlights = JsonConvert.DeserializeObject<List<Flight>>(File.ReadAllText(_fileName), new JsonSerializerSettings
                {
                    DateFormatString = "dMMMyyyy HH:mm"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception("Faild to upload flights.");
            }

            var aircraft = new PlaneModel("B737", 20);

            foreach (var flight in originalFlights)
            {
                flight.UsedSpace = 0;
                flight.Aircraft = aircraft;
                flight.Orders = new List<Order>();
            }

        }


    }
}
