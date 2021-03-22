using ElectricityBillAPI.Controllers;
using ElectricityBillAPI.Model;
using NUnit.Framework;

namespace ElectricityBillAPI.TDD
{
    public class DutyChargesTest
    {
        DutyChargesController dcController;
        DutyFcaBilled dfBilled;
        DutyChargesBilled result;

        #region "Duty Charges"
        [SetUp]
        public void Setup()
        {
            dcController = new DutyChargesController();
            dfBilled = new DutyFcaBilled();
            dfBilled.DutyChargesBilled = new DutyChargesBilled();
            dfBilled.FCAChargesBilled = new FCAChargesBilled();

            dfBilled.DutyChargesBilled.Slab1Rate = 0.09;
            dfBilled.DutyChargesBilled.Slab2Rate = 0.12;
            dfBilled.DutyChargesBilled.Slab3Rate = 0.12;
            dfBilled.DutyChargesBilled.Slab4Rate = 0.12;

            dfBilled.FCAChargesBilled.Slab1Rate = 0.13;
            dfBilled.FCAChargesBilled.Slab2Rate = 0.13;
            dfBilled.FCAChargesBilled.Slab3Rate = 0.13;
            dfBilled.FCAChargesBilled.Slab4Rate = 0.13;
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsZero()
        {
            result = dcController.Calculation(0);
            double actual = result.TotalDutyCharges;
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            result = dcController.Calculation(1);
            double actual = result.TotalDutyCharges;
            double expected = 0.102;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab1()
        {
            result = dcController.Calculation(40);
            double actual = result.TotalDutyCharges;
            double expected = 4.068;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab2()
        {
            result = dcController.Calculation(95);
            double actual = result.TotalDutyCharges;
            double expected = 11.187;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab3()
        {
            result = dcController.Calculation(250);
            double actual = result.TotalDutyCharges;
            double expected = 32.205;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab4()
        {
            result = dcController.Calculation(700);
            double actual = result.TotalDutyCharges;
            double expected = 93.225;
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            dcController = null;
        }

        #endregion
    }
}
