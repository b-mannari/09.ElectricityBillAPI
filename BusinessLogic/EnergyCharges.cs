using ElectricityBillAPI.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static ElectricityBillAPI.BusinessLogic.AllChargesEnum;

namespace ElectricityBillAPI.BusinessLogic
{
    public interface IElectricityCharge
    {
        public EnergyChargesBilled EnergyChargesCalculation(int Units);
    }

    public partial class EnergyCharges : IElectricityCharge
    {
        readonly string FilePath = Path.Combine(@"C:\TFS\GitHub\09.ElectricityBillAPI\ElectricityBillAPI" + "\\JSON", "EnrgySlabCharges.json");

        public EnergyChargesBilled GetEnrgySlabCharges()
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }
            EnergyChargesBilled enrgySlab = JsonConvert.DeserializeObject<EnergyChargesBilled>(strResponseContent);
            return enrgySlab;
        }

        public bool SetEnrgySlabCharges(EnergyChargesBilled eModel)
        {
            bool SlabChargesUpdated = false;
            var json = File.ReadAllText(FilePath);
            var enrgySlabList = JsonConvert.DeserializeObject<EnergyChargesBilled>(json);
            if (eModel != null)
            {
                enrgySlabList.Slab1Rate = eModel.Slab1Rate;
                enrgySlabList.Slab2Rate = eModel.Slab2Rate;
                enrgySlabList.Slab3Rate = eModel.Slab3Rate;
                enrgySlabList.Slab4Rate = eModel.Slab4Rate;

                File.WriteAllText(FilePath, JsonConvert.SerializeObject(enrgySlabList, Formatting.Indented));
                SlabChargesUpdated = true;
            }
            return SlabChargesUpdated;
        }

        public EnergyChargesBilled EnergyChargesCalculation(int Units)
        {
            EnergyChargesBilled eModel = GetEnrgySlabCharges();

            if (Units == 0)
            {
                eModel.TotalEnergyCharges = 0;
            }
            else if (Units >= (int)slab1range.min && Units <= (int)slab1range.max)
            {
                eModel.Slab1EnergyCharges = Units * eModel.Slab1Rate;
                eModel.TotalEnergyCharges = eModel.Slab1EnergyCharges;
            }
            else if (Units >= (int)slab2range.min && Units <= (int)slab2range.max)
            {
                eModel.Slab1EnergyCharges = (50 * eModel.Slab1Rate);
                eModel.Slab2EnergyCharges = ((Units - 50) * eModel.Slab2Rate);
                eModel.TotalEnergyCharges = eModel.Slab1EnergyCharges + eModel.Slab2EnergyCharges;
            }
            else if (Units >= (int)slab3range.min && Units <= (int)slab3range.max)
            {
                eModel.Slab1EnergyCharges = (50 * eModel.Slab1Rate);
                eModel.Slab2EnergyCharges = (100 * eModel.Slab2Rate);
                eModel.Slab3EnergyCharges = ((Units - 150) * eModel.Slab3Rate);
                eModel.TotalEnergyCharges = eModel.Slab1EnergyCharges + eModel.Slab2EnergyCharges + eModel.Slab3EnergyCharges;
            }
            else if (Units >= (int)slab4range.min)
            {
                eModel.Slab1EnergyCharges = (50 * eModel.Slab1Rate);
                eModel.Slab2EnergyCharges = (100 * eModel.Slab2Rate);
                eModel.Slab3EnergyCharges = (150 * eModel.Slab3Rate);
                eModel.Slab4EnergyCharges = ((Units - 300) * eModel.Slab4Rate);
                eModel.TotalEnergyCharges = eModel.Slab1EnergyCharges + eModel.Slab2EnergyCharges + eModel.Slab3EnergyCharges + eModel.Slab4EnergyCharges;
            }
            return eModel;
        }
    }
}