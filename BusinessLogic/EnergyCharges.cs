using ElectricityBillAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBillAPI.BusinessLogic
{
    public interface IElectricityCharge
    {
        public double GetSlabRate(int Slab);

        public double GetDutySlabRate(int Slab);

    }
    public partial class EnergyCharges : IElectricityCharge
    {
        public double GetDutySlabRate(int Slab)
        {
            return (Slab == 1) ? 0.09 : 0.12;
        }

        public double GetSlabRate(int Slab)
        {
            double returnSlabCharges = 0;

            switch (Slab)
            {
                case (int)ElectricitySlabs.slab1:
                    returnSlabCharges = Slabrates.slab1;
                    break;

                case (int)ElectricitySlabs.slab2:
                    returnSlabCharges = Slabrates.slab2;
                    break;

                case (int)ElectricitySlabs.slab3:
                    returnSlabCharges = Slabrates.slab3;
                    break;

                case (int)ElectricitySlabs.slab4:
                    returnSlabCharges = Slabrates.slab4;
                    break;
            }

            return returnSlabCharges;
        }

        public EnergyChargesBilled EnergyChargesCalculation(int Units)
        {
            EnergyChargesBilled ecbilled = new EnergyChargesBilled();

            if (Units == 0)
            {
                totalenergycharges = 0;
                ecbilled.TotalEnergyCharges = totalenergycharges;
                ecbilled.Units = Units;
                ecbilled.Slab = 0;

            }
            else if (Units >= (int)slab1range.min && Units <= (int)slab1range.max)
            {
                totalenergycharges = Units * GetSlabRate((int)ElectricitySlabs.slab1);
                Slab1Charges = totalenergycharges;
                ecbilled.Slab1Charges = Slab1Charges;
                ecbilled.TotalEnergyCharges = totalenergycharges;
                ecbilled.Units = Units;
                ecbilled.Slab = 1;
            }
            else if (Units >= (int)slab2range.min && Units <= (int)slab2range.max)
            {
                totalenergycharges = (50 * GetSlabRate((int)ElectricitySlabs.slab1)) + ((Units - 50) * GetSlabRate((int)ElectricitySlabs.slab2));
                Slab1Charges = (50 * GetSlabRate((int)ElectricitySlabs.slab1));
                Slab2Charges = ((Units - 50) * GetSlabRate((int)ElectricitySlabs.slab2));
                ecbilled.Slab1Charges = Slab1Charges;
                ecbilled.Slab2Charges = Slab2Charges;
                ecbilled.TotalEnergyCharges = totalenergycharges;
                ecbilled.Units = Units;
                ecbilled.Slab = 2;
            }
            else if (Units >= (int)slab3range.min && Units <= (int)slab3range.max)
            {

                totalenergycharges = (50 * GetSlabRate((int)ElectricitySlabs.slab1)) + (100 * GetSlabRate((int)ElectricitySlabs.slab2)) + ((Units - 150) * GetSlabRate((int)ElectricitySlabs.slab3));
                Slab1Charges = (50 * GetSlabRate((int)ElectricitySlabs.slab1));
                Slab2Charges = (100 * GetSlabRate((int)ElectricitySlabs.slab2));
                Slab3Charges = ((Units - 150) * GetSlabRate((int)ElectricitySlabs.slab3));
                ecbilled.Slab1Charges = Slab1Charges;
                ecbilled.Slab2Charges = Slab2Charges;
                ecbilled.Slab3Charges = Slab3Charges;
                ecbilled.TotalEnergyCharges = totalenergycharges;
                ecbilled.Units = Units;
                ecbilled.Slab = 3;
            }
            else if (Units >= (int)slab4range.min)
            {
                totalenergycharges = (50 * GetSlabRate((int)ElectricitySlabs.slab1)) + (100 * GetSlabRate((int)ElectricitySlabs.slab2)) + (150 * GetSlabRate((int)ElectricitySlabs.slab3)) + (Units - 300) * GetSlabRate((int)ElectricitySlabs.slab4);
                Slab1Charges = (50 * GetSlabRate((int)ElectricitySlabs.slab1));
                Slab2Charges = (100 * GetSlabRate((int)ElectricitySlabs.slab2));
                Slab3Charges = (150 * GetSlabRate((int)ElectricitySlabs.slab3));
                Slab4Charges = (Units - 300) * GetSlabRate((int)ElectricitySlabs.slab4);
                ecbilled.Slab1Charges = Slab1Charges;
                ecbilled.Slab2Charges = Slab2Charges;
                ecbilled.Slab3Charges = Slab3Charges;
                ecbilled.Slab4Charges = Slab4Charges;
                ecbilled.TotalEnergyCharges = totalenergycharges;
                ecbilled.Units = Units;
                ecbilled.Slab = 4;
            }
            return ecbilled;
        }
    }
}
