using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillAPI.BusinessLogic
{
    public partial class EnergyCharges
    {
        public double totalenergycharges;

        public double TotalDutyCharges;

        public double FCACharges = 0.13;
        public int Units { get; set; }
        public double Slab1Charges { get; set; }
        public double Slab2Charges { get; set; }
        public double Slab3Charges { get; set; }
        public double Slab4Charges { get; set; }
        public double Slab1DutyCharges { get; set; }
        public double Slab2DutyCharges { get; set; }
        public double Slab3DutyCharges { get; set; }
        public double Slab4DutyCharges { get; set; }
        public enum ElectricitySlabs
        {
            slab1 = 1,
            slab2 = 2,
            slab3 = 3,
            slab4 = 4,
        }
        public enum slab1range
        {
            min = 1,
            max = 50,
        }
        public enum slab2range
        {
            min = 51,
            max = 150,
        }

        public enum slab3range
        {
            min = 151,
            max = 300
        }

        public enum slab4range
        {
            min = 301
        }

        struct Slabrates
        {
            public const double slab1 = 4.05;
            public const double slab2 = 4.95;
            public const double slab3 = 6.30;
            public const double slab4 = 6.50;
        }

        public struct fcaSlabrates
        {
            public const double slab1 = 0.13;
            public const double slab2 = 0.13;
            public const double slab3 = 0.13;
            public const double slab4 = 0.13;
        }
    }
}
