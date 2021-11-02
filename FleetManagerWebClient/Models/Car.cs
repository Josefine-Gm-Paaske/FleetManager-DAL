using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagerWebClient.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
    }
}
