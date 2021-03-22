namespace ElectricityBillAPI.BusinessLogic
{
    public static class AllChargesEnum
    {
        public enum ElectricitySlabs
        {
            slab1 = 1,
            slab2 = 2,
            slab3 = 3,
            slab4 = 4,
        }
        public enum slab1range
        {
            min = 1,
            max = 50,
        }
        public enum slab2range
        {
            min = 51,
            max = 150,
        }

        public enum slab3range
        {
            min = 151,
            max = 300
        }

        public enum slab4range
        {
            min = 301
        }
    }
}
