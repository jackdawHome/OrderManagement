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
        /// <summary>
        /// Loads flights
        /// </summary>        
        Task LoadFlights(CancellationToken cancellationToken);

        /// <summary>
        /// Gets list of flights
        /// </summary>        
        Task<IEnumerable<Flight>> GetFlights(CancellationToken cancellationToken);

        /// <summary>
        /// Gets list of flights by destination
        /// </summary>
        /// <param name="destination"></param>       
        Task<IEnumerable<Flight>> GetFlightsByDestination(string destination, CancellationToken cancellationToken);
    }
}
