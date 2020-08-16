using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OrderManagement.DomainModel;
using OrderManagement.Repository;

namespace OrderManagement.Services
{
    class FlightService : IFlightService
    {
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task LoadFlights(CancellationToken cancellationToken)
        {
            await _flightRepository.LoadFlights(cancellationToken);
        }

        public async Task PrintFlights(CancellationToken cancellationToken)
        {
            Console.WriteLine("List of flights");
            string dateTimeFormat = "d-MMM-yyyy HH:mm";
            var flights = await _flightRepository.GetFlights(cancellationToken);
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.Number}, departure: {flight.Origin}, arrival: {flight.Destination}, " +
                    $"day: {flight.DepartureDate.ToString(dateTimeFormat)}");
            }
        }

        public async Task<IEnumerable<Flight>> GetFlightsByDestination(string destination, CancellationToken cancellationToken)
        {
            return await _flightRepository.GetFlightsByDestination(destination, cancellationToken);
        }

        private readonly IFlightRepository _flightRepository;
    }
}
