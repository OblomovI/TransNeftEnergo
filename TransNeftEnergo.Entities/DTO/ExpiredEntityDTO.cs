using System;

namespace TransNeftEnergo.Entities.DTO
{
    public class ExpiredEntityDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public DateTime InspectionDate { get; set; }
        public DateTime ExpiredDate { get; set; }

    }
}
