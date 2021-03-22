using ElectricityBillAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static ElectricityBillAPI.BusinessLogic.AllChargesEnum;
namespace ElectricityBillAPI.BusinessLogic
{
    public partial class DutyCharges
    {
        readonly string dFilePath = Path.Combine(@"C:\TFS\GitHub\09.ElectricityBillAPI\ElectricityBillAPI" + "\\JSON", "DutySlabCharges.json");

        readonly string fFilePath = Path.Combine(@"C:\TFS\GitHub\09.ElectricityBillAPI\ElectricityBillAPI" + "\\JSON", "FcaSlabCharges.json");

        public bool SetDutySlabCharges(DutyChargesBilled model)
        {
            bool dutySlabAdded = false;
            var json = System.IO.File.ReadAllText(dFilePath);
            var userList = JsonConvert.DeserializeObject<List<DutyChargesBilled>>(json);

            if (model != null)
            {
                userList.Add(model);
                System.IO.File.WriteAllText(dFilePath, JsonConvert.SerializeObject(userList, Formatting.Indented));
                dutySlabAdded = true;
            }
            return dutySlabAdded;
        }

        public DutyChargesBilled GetDutySlabCharges()
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(dFilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }
            DutyChargesBilled dutySlab = JsonConvert.DeserializeObject<DutyChargesBilled>(strResponseContent);
            return dutySlab;
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

        public DutyChargesBilled DutyChargesCalculation(int units)
        {
            DutyChargesBilled dutyModel = new DutyChargesBilled();
            DutyChargesBilled d_Slab = GetDutySlabCharges();
            FCAChargesBilled f_Slab = GetFcaSlabCharges();

            if (units == 0)
            {
                dutyModel.SlabDutyCharges = 0;
                dutyModel.FcaDutyCharges = 0;
                dutyModel.TotalDutyCharges = 0;
            }
            else if (units >= (int)slab1range.min && units <= (int)slab1range.max)
            {
                dutyModel.SlabDutyCharges = units * d_Slab.Slab1Rate;
                dutyModel.FcaDutyCharges =
                    Math.Round((dutyModel.SlabDutyCharges * f_Slab.Slab1Rate), 3);
            }
            else if (units >= (int)slab2range.min && units <= (int)slab2range.max)
            {
                dutyModel.SlabDutyCharges = (50 * d_Slab.Slab1Rate)
                    + ((units - 50) * d_Slab.Slab2Rate);
                dutyModel.FcaDutyCharges =
                    Math.Round((dutyModel.SlabDutyCharges * f_Slab.Slab2Rate), 3);
            }
            else if (units >= (int)slab3range.min && units <= (int)slab3range.max)
            {
                dutyModel.SlabDutyCharges = (50 * d_Slab.Slab1Rate)
                    + (100 * d_Slab.Slab2Rate) + ((units - 150) * d_Slab.Slab3Rate);
                dutyModel.FcaDutyCharges =
                    Math.Round((dutyModel.SlabDutyCharges * f_Slab.Slab3Rate), 3);
            }
            else if (units >= (int)slab4range.min)
            {
                dutyModel.SlabDutyCharges =
                    (50 * d_Slab.Slab1Rate) + (100 * d_Slab.Slab2Rate)
                    + (150 * d_Slab.Slab3Rate) + (units - 300) * d_Slab.Slab4Rate;
                dutyModel.FcaDutyCharges =
                    Math.Round((dutyModel.SlabDutyCharges * f_Slab.Slab4Rate), 3);
            }
            dutyModel.SlabDutyCharges = Math.Round(dutyModel.SlabDutyCharges, 3);
            dutyModel.TotalDutyCharges = Math.Round((dutyModel.SlabDutyCharges + dutyModel.FcaDutyCharges), 3);
            return dutyModel;
        }


        public DutyFcaBilled DutyChargesCalculation1(int units)
        {
            DutyFcaBilled dutyModel = new DutyFcaBilled();
            DutyChargesBilled dtySlab = GetDutySlabCharges();
            FCAChargesBilled fcaSlab = GetFcaSlabCharges();

            dutyModel.DutyChargesBilled = new DutyChargesBilled();
            dutyModel.FCAChargesBilled = new FCAChargesBilled();

            if (units == 0)
            {
                dutyModel.DutyChargesBilled.SlabDutyCharges = 0;
                dutyModel.DutyChargesBilled.FcaDutyCharges = 0;
                dutyModel.DutyChargesBilled.TotalDutyCharges = 0;
            }
            else if (units >= (int)slab1range.min && units <= (int)slab1range.max)
            {
                dutyModel.DutyChargesBilled.SlabDutyCharges = units * dtySlab.Slab1Rate;
                dutyModel.DutyChargesBilled.FcaDutyCharges =
                    Math.Round((dutyModel.DutyChargesBilled.SlabDutyCharges * fcaSlab.Slab1Rate), 3);
            }
            else if (units >= (int)slab2range.min && units <= (int)slab2range.max)
            {
                dutyModel.DutyChargesBilled.SlabDutyCharges = (50 * dtySlab.Slab1Rate)
                    + ((units - 50) * dtySlab.Slab2Rate);
                dutyModel.DutyChargesBilled.FcaDutyCharges =
                    Math.Round((dutyModel.DutyChargesBilled.SlabDutyCharges * fcaSlab.Slab2Rate), 3);
            }
            else if (units >= (int)slab3range.min && units <= (int)slab3range.max)
            {
                dutyModel.DutyChargesBilled.SlabDutyCharges = (50 * dtySlab.Slab1Rate)
                    + (100 * dtySlab.Slab2Rate) + ((units - 150) * dtySlab.Slab3Rate);
                dutyModel.DutyChargesBilled.FcaDutyCharges =
                    Math.Round((dutyModel.DutyChargesBilled.SlabDutyCharges * fcaSlab.Slab3Rate), 3);
            }
            else if (units >= (int)slab4range.min)
            {
                dutyModel.DutyChargesBilled.SlabDutyCharges =
                    (50 * dtySlab.Slab1Rate) + (100 * dtySlab.Slab2Rate)
                    + (150 * dtySlab.Slab3Rate) + (units - 300) * dtySlab.Slab1Rate;
                dutyModel.DutyChargesBilled.FcaDutyCharges =
                    Math.Round((dutyModel.DutyChargesBilled.SlabDutyCharges * fcaSlab.Slab4Rate), 3);
            }
            dutyModel.DutyChargesBilled.SlabDutyCharges = Math.Round(dutyModel.DutyChargesBilled.SlabDutyCharges, 3);
            dutyModel.DutyChargesBilled.TotalDutyCharges = Math.Round((dutyModel.DutyChargesBilled.SlabDutyCharges + dutyModel.DutyChargesBilled.FcaDutyCharges), 3);
            return dutyModel;
        }
    }
}