using ElectricityBillAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillAPI.BusinessLogic
{
    public class FCACharges : EnergyCharges
    {
        public FCAChargesBilled FcaChargesCalculation(int units)
        {
            double fcaSlabCharges = 0;
            FCAChargesBilled fcabilled = new FCAChargesBilled();
            if (units == 0)
            {
                fcaSlabCharges = 0;
            }
            else if (units >= (int)slab1range.min && units <= (int)slab1range.max)
            {
                fcaSlabCharges = units * fcaSlabrates.slab1;
                fcabilled.Slab1Charges = units * fcaSlabrates.slab1;
            }
            else if (units >= (int)slab2range.min && units <= (int)slab2range.max)
            {
                fcaSlabCharges = (50 * fcaSlabrates.slab1)
                    + ((units - 50) * fcaSlabrates.slab2);
                fcabilled.Slab1Charges = (50 * fcaSlabrates.slab1);
                fcabilled.Slab2Charges = ((units - 50) * fcaSlabrates.slab2);
            }
            else if (units >= (int)slab3range.min && units <= (int)slab3range.max)
            {
                fcaSlabCharges = (50 * fcaSlabrates.slab1)
                    + (100 * fcaSlabrates.slab2)
                    + ((units - 150) * fcaSlabrates.slab3);
                fcabilled.Slab1Charges = (50 * fcaSlabrates.slab1);
                fcabilled.Slab2Charges = (100 * fcaSlabrates.slab2);
                fcabilled.Slab3Charges = ((units - 150) * fcaSlabrates.slab3);
            }
            else if (units >= (int)slab4range.min)
            {
                fcaSlabCharges =
                    (50 * fcaSlabrates.slab1)
                    + (100 * fcaSlabrates.slab2)
                    + (150 * fcaSlabrates.slab3)
                    + (units - 300) * fcaSlabrates.slab4;
                fcabilled.Slab1Charges = (50 * fcaSlabrates.slab1);
                fcabilled.Slab2Charges = (100 * fcaSlabrates.slab2);
                fcabilled.Slab3Charges = (150 * fcaSlabrates.slab3);
                fcabilled.Slab4Charges = (units - 300) * fcaSlabrates.slab4;
            }
            FCACharges = Math.Round((fcaSlabCharges), 3);
            fcabilled.fcachargestotal = FCACharges;
            return fcabilled;
        }
    }
}
