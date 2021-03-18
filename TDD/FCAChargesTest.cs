using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Controllers;
using ElectricityBillAPI.Model;
using NUnit.Framework;


namespace ElectricityBillAPI.TDD
{
    public class FCAChargesTest
    {
       FCAChargesController fcaController;

        [SetUp]
        public void Setup()
        {
            fcaController = new FCAChargesController();

        }
        #region "FCA Charges"

        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab1()
        {
            FCAChargesBilled result = fcaController.Calculation(1);
            double actual = result.fcachargestotal;
            double expected = 0.13;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab2()
        {
            FCAChargesBilled result = fcaController.Calculation(51);
            double actual = result.fcachargestotal;
            double expected = 6.63;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab3()
        {
            FCAChargesBilled result = fcaController.Calculation(151);
            double actual = result.fcachargestotal;
            double expected = 19.63;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnFCAChargesWhenUnitsConsumedForSlab4()
        {
            FCAChargesBilled result = fcaController.Calculation(301);
            double actual = result.fcachargestotal;
            double expected = 39.13;
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            fcaController = null;
        }

        #endregion
    }
}
