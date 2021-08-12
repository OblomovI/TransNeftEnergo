using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftEnergo.DTO
{
    public class CalculatingMeterDTO
    {
        public string PowerSupplyPointName { get; set; }
        public int PowerMeasuringPointId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
