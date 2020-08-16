using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.DomainModel
{
    public class PlaneModel
    {
        /// <summary>
        /// ctor
        /// </summary>        
        public PlaneModel (string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
        }
        /// <summary>
        /// Plane model identifier
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Plane model identifier
        /// </summary>
        public int Capacity { get; }
    }
}
