using OrderManagement.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public interface IFlightRepository
    {
        Task LoadFlights(CancellationToken cancellationToken);

        Task<IEnumerable<Flight>> GetFlights(CancellationToken cancellationToken);

        Task<IEnumerable<Flight>> GetFlightsByDestination(string destination, CancellationToken cancellationToken);
    }
}
