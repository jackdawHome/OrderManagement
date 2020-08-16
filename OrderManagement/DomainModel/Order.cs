using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.DomainModel
{
    public class Order
    {
        
        /// <summary>
        /// Order number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Order destination
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatus Status { get; set; }
        
        /// <summary>
        /// Space unit number requered for an order 
        /// </summary>
        public int SpaceUnit { get; set; }

        public Flight Flight { get; set; }

    }
}
