using OrderManagement.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public interface IFlightService
    {
        Task LoadFlights(CancellationToken cancellationToken);

        Task PrintFlights(CancellationToken cancellationToken);

        Task<IEnumerable<Flight>> GetFlightsByDestination(string destination, CancellationToken cancellationToken);
    }
}
