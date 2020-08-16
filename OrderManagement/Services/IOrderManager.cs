using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public interface IOrderManager
    {
        Task ScheduleOrders(CancellationToken cancellationToken);
    }
}
