using OrderManagement.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Loads orders into the system
        /// </summary>
        /// <returns></returns>
        Task LoadOrders(CancellationToken cancellationToken);

        Task<IEnumerable<string>> GetDestinationsForUnscheduledOrders(CancellationToken cancellationToken);

        Task<IEnumerable<Order>> GetNUnscheduledOrdersByDestination(string destination, int maxSpace, CancellationToken cancellationToken);

        Task<IEnumerable<Order>> GetOrdersByStatus(OrderStatus orderStatus, CancellationToken cancellationToken);

        Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
    }
}
