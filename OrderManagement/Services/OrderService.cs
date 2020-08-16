using OrderManagement.DomainModel;
using OrderManagement.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class OrderService : IOrderService
    {

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task LoadOrders(CancellationToken cancellationToken)
        {            
            await _orderRepository.LoadOrders(cancellationToken);            
        }

        public async Task<IEnumerable<string>> GetDestinationsForUnscheduledOrders(CancellationToken cancellationToken)
        {
            return await _orderRepository.GetDestinationsForUnscheduledOrders(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetNUnscheduledOrdersByDestination(string destination, int maxSpace, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetNUnscheduledOrdersByDestination(destination, maxSpace, cancellationToken);
        }

        public async Task PrintOrders(CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(cancellationToken);
            string dateTimeFormat = "d-MMM-yyyy HH:mm";
            Console.WriteLine("List of orders");
            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.Assigned)
                {
                    Console.WriteLine($"order: {order.Number}, flightNumber: {order.Flight.Number}, departure: {order.Flight.Origin}," +
                        $" arrival: {order.Flight.Destination}, day: {order.Flight.DepartureDate.ToString(dateTimeFormat)}");
                }
                else if (order.Status == OrderStatus.Imported) 
                {
                    Console.WriteLine($"order: {order.Number}, flightNumber: not scheduled");
                } 
                
            }
        }

        private readonly IOrderRepository _orderRepository;
    }
}
