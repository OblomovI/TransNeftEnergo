using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftEnergo.DTO
{
    public class CalculatingMeterDTO
    {
        public int Id { get; set; }
        public string PowerSuplyPointName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
