using ElectricityBillAPI.BusinessLogic;
using ElectricityBillAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityBillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyChargesController : Controller
    {
        //public IElectricityCharge _electricityCharge;
        readonly EnergyCharges energyCharges = new EnergyCharges();

        //string contentRootPath = ""; string FilePath = "";
        //private IWebHostEnvironment _hostingEnvironment;
        //public EnergyChargesController(IWebHostEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //    //_electricityCharge = electricityCharge;
        //    contentRootPath = _hostingEnvironment.ContentRootPath;
        //    FilePath = Path.Combine(contentRootPath + "\\JSON", "EnrgySlabCharges.json");
        //}


        //POST api/<EnergyChargesController>/5
        [HttpGet("/api/EnergyCharges/Calculation")]
        public EnergyChargesBilled Calculation(int units)
        {
            EnergyChargesBilled _eModel = energyCharges.EnergyChargesCalculation(units);
            return _eModel;
        }

        [HttpPost("/api/EnergyCharges/SetCharges")]
        public bool SetCharges([FromBody] EnergyChargesBilled eModel)
        {
            return energyCharges.SetEnrgySlabCharges(eModel);
        }

        // GET: api/<EnergyChargesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}