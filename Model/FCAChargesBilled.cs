namespace ElectricityBillAPI.Model
{
    public class FCAChargesBilled
    {
        public double Slab1Rate{ get; set; }
        public double Slab2Rate{ get; set; }
        public double Slab3Rate{ get; set; }
        public double Slab4Rate{ get; set; }


        public double Slab1FcaCharges { get; set; }
        public double Slab2FcaCharges { get; set; }
        public double Slab3FcaCharges { get; set; }
        public double Slab4FcaCharges { get; set; }

        public double FcaChargesTotal { get; set; }
    }
}