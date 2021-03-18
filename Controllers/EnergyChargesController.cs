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
    public class EnergyChargesController : ControllerBase
    {
        // GET: api/<EnergyChargesController>

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnergyChargesController>/5
        [HttpGet("/api/EnergyCharges/Calculation")]
        public EnergyChargesBilled Calculation(int units)
        {
            EnergyCharges energyCharges = new EnergyCharges();
            EnergyChargesBilled ecbilled = new EnergyChargesBilled();
            ecbilled = energyCharges.EnergyChargesCalculation(units);
            return ecbilled;
        }

        

        // POST api/<EnergyChargesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


    }

}
