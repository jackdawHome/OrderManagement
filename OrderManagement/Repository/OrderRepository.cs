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
    public class OrderRepository : IOrderRepository
    {
        private readonly string _fileName = "coding-assigment-orders.json";
        private List<Order> originalOrderList;
        
        public OrderRepository()
        {
            //_fileName = FileName;
        }

        public async Task<IEnumerable<string>> GetDestinationsForUnscheduledOrders(CancellationToken cancellationToken)
        {
            if (originalOrderList == null)
            {
                throw new Exception("Orders are not loaded");
            }
            return originalOrderList.Where(x => x.Status == OrderStatus.Imported).Select(x => x.Destination).Distinct();
        }

        public async Task<IEnumerable<Order>> GetNUnscheduledOrdersByDestination(string destination, int maxSpace, CancellationToken cancellationToken)
        {
            if (originalOrderList == null)
            {
                throw new Exception("Orders are not loaded");
            }
            var count = 0;
            return originalOrderList.Where(x => x.Status == OrderStatus.Imported && x.Destination == destination)
                .TakeWhile(x => (count += x.SpaceUnit) <= maxSpace);
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
        {
            if (originalOrderList == null)
            {
                throw new Exception("Orders are not loaded");
            }

            return originalOrderList.OrderBy(x => x.Number);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatus(OrderStatus orderStatus, CancellationToken cancellationToken)
        {
            if (originalOrderList == null)
            {
                throw new Exception("Orders are not loaded");
            }

            return originalOrderList.Where(x => x.Status == orderStatus)
                .OrderBy(x => x.Number);
        }

        public async Task LoadOrders(CancellationToken cancellationToken)
        {
            SortedDictionary<string, Order> dOrder = new SortedDictionary<string, Order>();
            originalOrderList = new List<Order>();

            try
            {
                dOrder = JsonConvert.DeserializeObject<SortedDictionary<string, Order>>(File.ReadAllText(_fileName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception("Falied to upload orders.");
            }

            foreach (var key in dOrder.Keys)
            {

                dOrder[key].Number = key;
                dOrder[key].Status = OrderStatus.Imported;
                dOrder[key].SpaceUnit = 1;

                originalOrderList.Add(dOrder[key]);


            }

        }
    }
}
