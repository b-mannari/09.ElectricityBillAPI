namespace ElectricityBillAPI.Model
{
    public class DutyChargesBilled
    {
        public double Slab1Rate{ get; set; }
        public double Slab2Rate{ get; set; }
        public double Slab3Rate{ get; set; }
        public double Slab4Rate{ get; set; }

        public double Slab1DutyCharges { get; set; }
        public double Slab2DutyCharges { get; set; }
        public double Slab3DutyCharges { get; set; }
        public double Slab4DutyCharges { get; set; }

        public double SlabDutyCharges { get; set; }
        public double FcaDutyCharges { get; set; }
        public double TotalDutyCharges { get; set; }
    }
}