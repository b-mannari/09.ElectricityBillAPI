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
    public class DutyChargesTest
    {
        DutyChargesController dcController;

        [SetUp]
        public void Setup()
        {
            dcController = new DutyChargesController();
        }

        #region "Duty Charges"

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsZero()
        {
            DutyChargesBilled result = dcController.Calculation(0);
            double actual = result.totaldutycharges;
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedIsOneForSlab1()
        {
            DutyChargesBilled result = dcController.Calculation(1);
            double actual = result.totaldutycharges;
            double expected = 0.102;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab1()
        {
            DutyChargesBilled result = dcController.Calculation(40);
            double actual = result.totaldutycharges;
            double expected = 4.068;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab2()
        {
            DutyChargesBilled result = dcController.Calculation(95);
            double actual = result.totaldutycharges;
            double expected = 11.187;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab3()
        {
            DutyChargesBilled result = dcController.Calculation(250);
            double actual = result.totaldutycharges;
            double expected = 32.205;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldReturnDutyChargesWhenUnitsConsumedForSlab4()
        {
            DutyChargesBilled result = dcController.Calculation(700);
            double actual = result.totaldutycharges;
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
