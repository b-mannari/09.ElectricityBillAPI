using ElectricityBillAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static ElectricityBillAPI.BusinessLogic.AllChargesEnum;

namespace ElectricityBillAPI.BusinessLogic
{
    public class FCACharges : EnergyCharges
    {

        readonly string fFilePath = Path.Combine(@"C:\TFS\GitHub\09.ElectricityBillAPI\ElectricityBillAPI" + "\\JSON", "FcaSlabCharges.json");

        public bool SetFcaSlabCharges(FCAChargesBilled model)
        {
            bool dutySlabAdded = false;
            var json = System.IO.File.ReadAllText(fFilePath);
            var fcaSlabList = JsonConvert.DeserializeObject<List<FCAChargesBilled>>(json);

            if (model != null)
            {
                fcaSlabList.Add(model);
                System.IO.File.WriteAllText(fFilePath, JsonConvert.SerializeObject(fcaSlabList, Formatting.Indented));
                dutySlabAdded = true;
            }
            return dutySlabAdded;
        }

        public FCAChargesBilled GetFcaSlabCharges()
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(fFilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }
            FCAChargesBilled fcaSlab = JsonConvert.DeserializeObject<FCAChargesBilled>(strResponseContent);
            return fcaSlab;
        }

        public FCAChargesBilled FcaChargesCalculation(int units)
        {
            FCAChargesBilled fcaSlabRate = GetFcaSlabCharges();
            FCAChargesBilled fcaModel = new FCAChargesBilled();
            if (units == 0)
            {
                fcaModel.FcaChargesTotal = 0;
            }
            else if (units >= (int)slab1range.min && units <= (int)slab1range.max)
            {
                fcaModel.Slab1FcaCharges = units * fcaSlabRate.Slab1Rate;
                fcaModel.FcaChargesTotal = fcaModel.Slab1FcaCharges;
            }
            else if (units >= (int)slab2range.min && units <= (int)slab2range.max)
            {
                fcaModel.Slab1FcaCharges = (50 * fcaSlabRate.Slab1Rate);
                fcaModel.Slab2FcaCharges = ((units - 50) * fcaSlabRate.Slab2Rate);
                fcaModel.FcaChargesTotal = (fcaModel.Slab1FcaCharges + fcaModel.Slab2FcaCharges);
            }
            else if (units >= (int)slab3range.min && units <= (int)slab3range.max)
            {
                fcaModel.Slab1FcaCharges = (50 * fcaSlabRate.Slab1Rate);
                fcaModel.Slab2FcaCharges = (100 * fcaSlabRate.Slab2Rate);
                fcaModel.Slab3FcaCharges = ((units - 150) * fcaSlabRate.Slab3Rate);
                fcaModel.FcaChargesTotal = (fcaModel.Slab1FcaCharges + fcaModel.Slab2FcaCharges + fcaModel.Slab3FcaCharges);
            }
            else if (units >= (int)slab4range.min)
            {
                fcaModel.Slab1FcaCharges = (50 * fcaSlabRate.Slab1Rate);
                fcaModel.Slab2FcaCharges = (100 * fcaSlabRate.Slab2Rate);
                fcaModel.Slab3FcaCharges = (150 * fcaSlabRate.Slab3Rate);
                fcaModel.Slab4FcaCharges = ((units - 300) * fcaSlabRate.Slab4Rate);
                fcaModel.FcaChargesTotal = (fcaModel.Slab1FcaCharges + fcaModel.Slab2FcaCharges + fcaModel.Slab3FcaCharges + fcaModel.Slab4FcaCharges);
            }
            fcaModel.FcaChargesTotal = Math.Round((fcaModel.FcaChargesTotal), 3);
            return fcaModel;
        }
    }
}
