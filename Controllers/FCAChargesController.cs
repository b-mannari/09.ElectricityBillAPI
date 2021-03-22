using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityBillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FCAChargesController : ControllerBase
    {
        FCACharges fcaCharges = new FCACharges();
        // GET: api/<DutyChargesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnergyChargesController>/5
        [HttpGet("/api/FCACharges/Calculation")]
        public FCAChargesBilled Calculation(int units)
        {
            FCAChargesBilled fcaModel = fcaCharges.FcaChargesCalculation(units);
            return fcaModel;
        }

        [HttpPost("/api/FCACharges/SetCharges")]
        public bool SetCharges([FromBody] FCAChargesBilled fModel)
        {
            return fcaCharges.SetFcaSlabCharges(fModel);
        }
    }
}
