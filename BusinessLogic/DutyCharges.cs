using ElectricityBillAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillAPI.BusinessLogic
{
    public partial class DutyCharges : EnergyCharges
    {
        public DutyChargesBilled DutyChargesCalculation(int units)
        {
            double SlabWiseCharges = 0;
            DutyChargesBilled dcbilled = new DutyChargesBilled();
            if (units == 0)
            {
                SlabWiseCharges = 0;
            }
            else if (units >= (int)slab1range.min && units <= (int)slab1range.max)
            {
                SlabWiseCharges = units * GetDutySlabRate((int)ElectricitySlabs.slab1);
            }
            else if (units >= (int)slab2range.min && units <= (int)slab2range.max)
            {
                SlabWiseCharges = (50 * GetDutySlabRate((int)ElectricitySlabs.slab1))
                    + ((units - 50) * GetDutySlabRate((int)ElectricitySlabs.slab2));
            }
            else if (units >= (int)slab3range.min && units <= (int)slab3range.max)
            {
                SlabWiseCharges = (50 * GetDutySlabRate((int)ElectricitySlabs.slab1))
                    + (100 * GetDutySlabRate((int)ElectricitySlabs.slab2)) 
                    + ((units - 150) * GetDutySlabRate((int)ElectricitySlabs.slab3));
            }
            else if (units >= (int)slab4range.min)
            {
                SlabWiseCharges =
                    (50 * GetDutySlabRate((int)ElectricitySlabs.slab1))
                    + (100 * GetDutySlabRate((int)ElectricitySlabs.slab2))
                    + (150 * GetDutySlabRate((int)ElectricitySlabs.slab3))
                    + (units - 300) * GetDutySlabRate((int)ElectricitySlabs.slab4);
            }

            dcbilled.fcadutycharges = Math.Round((SlabWiseCharges * FCACharges),3);
            TotalDutyCharges = Math.Round(SlabWiseCharges + (SlabWiseCharges * FCACharges),3);
            dcbilled.totaldutycharges = Math.Round(TotalDutyCharges,3);
            dcbilled.slabdutycharges = Math.Round(SlabWiseCharges,3);

            return dcbilled;
        }
    }
}
