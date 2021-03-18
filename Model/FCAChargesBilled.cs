using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillAPI.Model
{
    public class FCAChargesBilled
    {
        public double fcachargestotal { get; set; }
        public double Slab1Charges { get; set; }
        public double Slab2Charges { get; set; }
        public double Slab3Charges { get; set; }
        public double Slab4Charges { get; set; }
    }
}
