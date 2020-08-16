using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using OrderManagement.DomainModel;

namespace OrderManagement.Services
{
    public class OrderManager : IOrderManager
    {
        public OrderManager(IOrderService orderService, IFlightService flightService)
        {
            _orderService = orderService;
            _flightService = flightService;
        }


        public async Task ScheduleOrders(CancellationToken cancellationToken)
        {
            IEnumerable<string> dest = await _orderService.GetDestinationsForUnscheduledOrders(cancellationToken);
            

            foreach (var t in dest)
            {
                
                var flights = await _flightService.GetFlightsByDestination(t, cancellationToken);
                foreach (var f in flights)
                {
                    var remainingCapacity = f.Aircraft.Capacity - f.UsedSpace;
                    if (remainingCapacity > 0) 
                    {
                        IList<Order> orders = (await _orderService.GetNUnscheduledOrdersByDestination(f.Destination, remainingCapacity, cancellationToken)).ToList();
                        
                        var actualUsedSpace = orders.Sum(x => x.SpaceUnit);
                        f.UsedSpace += actualUsedSpace;
                        f.Orders.AddRange(orders);
                        foreach (var order in orders)
                        {
                            order.Status = OrderStatus.Assigned;
                            order.Flight = f;
                        }
                    }
                    
                    
                }

            }


        }

        private readonly IOrderService _orderService;
        private readonly IFlightService _flightService;
    }
}
