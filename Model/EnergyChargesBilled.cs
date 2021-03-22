namespace ElectricityBillAPI.Model
{
    public class EnergyChargesBilled
    {
        public double Slab1EnergyCharges { get; set; }
        public double Slab2EnergyCharges { get; set; }
        public double Slab3EnergyCharges { get; set; }
        public double Slab4EnergyCharges { get; set; }

        public double Slab1Rate{ get; set; }
        public double Slab2Rate{ get; set; }
        public double Slab3Rate{ get; set; }
        public double Slab4Rate{ get; set; }
        public double TotalEnergyCharges { get; set; }
    }
}