using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.DomainModel
{
    public enum OrderStatus
    {
        /// <summary>
        /// Order impored into the system
        /// </summary>
        Imported = 1,

        /// <summary>
        /// Order assignet to an aircraft
        /// </summary>
        Assigned = 2,

        /// <summary>
        /// Order delivered to a destination
        /// </summary>
        Complited = 3
    }
}
