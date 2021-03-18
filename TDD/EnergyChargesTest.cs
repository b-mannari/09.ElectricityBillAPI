using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Controllers;
using ElectricityBillAPI.Model;
using NUnit.Framework;
using System;


namespace ElectricityBillAPI.TDD
{
    public class EnergyChargesTest
    {
        EnergyChargesController ecController;

        [SetUp]
        public void Setup()
        {
            ecController = new EnergyChargesController();
        }


        #region "Energy Charges"

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsZero()
        {
            EnergyChargesBilled result = ecController.Calculation(0);
            double actual = result.TotalEnergyCharges;
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            EnergyChargesBilled result = ecController.Calculation(1);
            double actual = result.TotalEnergyCharges;
            double expected = 4.05;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab1()
        {
            EnergyChargesBilled result = ecController.Calculation(45);
            double actual = result.TotalEnergyCharges;
            double expected = 182.25;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab2()
        {
            EnergyChargesBilled result = ecController.Calculation(51);
            double actual = result.TotalEnergyCharges;
            double expected = 207.45;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab3()
        {
            EnergyChargesBilled result = ecController.Calculation(151);
            double actual = result.TotalEnergyCharges;
            double expected = 703.80;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnEnergyChargesWhenUnitsConsumedForSlab4()
        {
            EnergyChargesBilled result = ecController.Calculation(301);
            double actual = result.TotalEnergyCharges;
            double expected = 1649.00;
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