using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Controllers;
using ElectricityBillAPI.Model;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace ElectricityBillAPI.TDD
{
    public class EnergyChargesTest
    {
        public IWebHostEnvironment _hostingEnvironment;
        public IElectricityCharge _electricityCharge;
        EnergyChargesController ecController;
        readonly EnergyChargesBilled inputModel = new EnergyChargesBilled();
        EnergyChargesBilled outputModel = new EnergyChargesBilled();
        int units = 0; double expected = 0;

        [SetUp]
        public void Setup()
        {
            //ecController = new EnergyChargesController(_electricityCharge);
            ecController = new EnergyChargesController();
        }

        #region "Energy Charges"

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsZero()
        {
            units = 0; expected = 0;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnTrueWhenTheEnergySlabRatesAreSet()
        {
            inputModel.Slab1Rate = 4.05;
            inputModel.Slab2Rate = 4.95;
            inputModel.Slab3Rate = 6.30;
            inputModel.Slab4Rate = 6.50;

            bool result = ecController.SetCharges(inputModel);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            units = 1; expected = 4.05;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);

            //outputModel.TotalEnergyCharges = 4.05;
            //var service = new Mock<IElectricityCharge>();

            //service.Setup(m => m.EnergyChargesCalculation(It.IsAny<int>(),
            //                It.IsAny<EnergyChargesBilled>())).Returns(outputModel);

            //ecController = new EnergyChargesController(service.Object);
            //double actual = ecController.Calculation(units, inputModel).TotalEnergyCharges;
            //service.Verify(x => x.EnergyChargesCalculation(units, inputModel), Times.AtLeastOnce());
            //Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab1()
        {
            units = 45; expected = 182.25;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab2()
        {
            units = 51; expected = 207.45;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab3()
        {
            units = 151; expected = 703.80;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab4()
        {
            units = 301; expected = 1649.00;
            outputModel = ecController.Calculation(units);
            double actual = outputModel.TotalEnergyCharges;
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            ecController = null;
        }

        #endregion

    }
}