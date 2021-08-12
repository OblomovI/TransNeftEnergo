using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftEnergo.DTO
{
    public class PostPowerMeasuringPointParam
    {
        public string Name { get; set; }
        public int CurrentMeterId { get; set; }
        public int CurrentTransformerId { get; set; }
        public int VoltageTransformerId { get; set; }
        public int ConsumptionObjectId { get; set; }
    }
}
