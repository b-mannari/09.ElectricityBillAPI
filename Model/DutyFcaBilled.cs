namespace ElectricityBillAPI.Model
{
    public class DutyFcaBilled
    {
        public DutyChargesBilled DutyChargesBilled { get; set; }
        public FCAChargesBilled FCAChargesBilled { get; set; }
    }
}