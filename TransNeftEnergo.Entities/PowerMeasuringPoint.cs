using System;
using System.Collections.Generic;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class PowerMeasuringPoint: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PowerMeasuringPointToCalculatingMeter> PowerMeasuringPointToCalculatingMeters { get; set; }

        public int ConsumptionObjectId { get; set; }
        public ConsumptionObject ConsumptionObject { get; set; }

        public CurrentMeter CurrentMeter { get; set; }
        
        public CurrentTransformer CurrentTransformer { get; set; }

        public VoltageTransformer VoltageTransformer { get; set; }

        public PowerMeasuringPoint()
        {
            PowerMeasuringPointToCalculatingMeters = new List <PowerMeasuringPointToCalculatingMeter>();
        }

        public IDbItem Initialize()
        {
            
            var rnd = new Random();
            var item = new PowerMeasuringPoint();

            item.CurrentTransformer = new CurrentTransformer().Initialize() as CurrentTransformer;
            item.CurrentMeter = new CurrentMeter().Initialize() as CurrentMeter;
            item.Name = $"Точка измерения электроэнергии {rnd.Next(0, 50)}";
            item.VoltageTransformer = new VoltageTransformer().Initialize() as VoltageTransformer;

            //item.PowerMeasuringPointToCalculatingMeters.Add(new PowerMeasuringPointToCalculatingMeter().Initialize() as PowerMeasuringPointToCalculatingMeter);

            return item;

        }
            
    }
}
