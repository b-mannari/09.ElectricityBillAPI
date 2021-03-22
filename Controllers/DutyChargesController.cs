using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityBillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyChargesController : ControllerBase
    {
        DutyCharges dutyCharges = new DutyCharges();
        // GET: api/<DutyChargesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnergyChargesController>/5
        [HttpGet("/api/DutyCharges/Calculation")]
        public DutyChargesBilled Calculation(int units)
        {
            DutyChargesBilled dutyModel = dutyCharges.DutyChargesCalculation(units);
            return dutyModel;
        }

        [HttpPost("/api/DutyCharges/SetCharges")]
        public bool SetCharges([FromBody] DutyChargesBilled dModel)
        {
            return dutyCharges.SetDutySlabCharges(dModel);
        }
    }
}
