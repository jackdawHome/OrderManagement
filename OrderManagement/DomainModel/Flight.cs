using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.DomainModel
{
    public class Flight
    {
        public string CarrierCode { get; set; } 
        public int Number { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public PlaneModel Aircraft { get; set; }

        public int UsedSpace { get; set; }

        public List<Order> Orders { get; set; }
    }
}
