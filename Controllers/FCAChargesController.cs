using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityBillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FCAChargesController : ControllerBase
    {
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
            FCACharges fcaCharges = new FCACharges();
            FCAChargesBilled fcabilled = new FCAChargesBilled();
            fcabilled = fcaCharges.FcaChargesCalculation(units);
            return fcabilled;
        }
    }
}
