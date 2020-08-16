using OrderManagement.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public interface IOrderService
    {
        Task LoadOrders(CancellationToken cancellationToken);

        Task<IEnumerable<string>> GetDestinationsForUnscheduledOrders(CancellationToken cancellationToken);

        Task<IEnumerable<Order>> GetNUnscheduledOrdersByDestination(string destination, int maxSpace, CancellationToken cancellationToken);

        Task PrintOrders(CancellationToken cancellationToken);
    }
}
