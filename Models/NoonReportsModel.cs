using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetMan.Models
{
    public class NoonReport
    {
        public int Id { get; set; }
        public int VesselId { get; set; }
        public DateTime ReportDateTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public double Speed { get; set; }
        public double Draft { get; set; }
        public double FuelConsumption { get; set; }
    }
}