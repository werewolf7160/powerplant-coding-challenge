using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using powerplant_coding_challenge_branch.Class;

namespace powerplant_coding_challenge_branch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerPlantCalculatorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] object value)
        {
            try
            {
                var dataWrapper = JsonConvert.DeserializeObject<DataWrapper>(value.ToString());

                if (dataWrapper == null) return BadRequest("Data are empty");
                var powerPlantResolver = new PowerPlantResolver();
                //TODO implement custom serialization to use IPowerPlant
                var res = powerPlantResolver.ResolvePowerPlant(dataWrapper.Powerplants, dataWrapper.FuelPrice, dataWrapper.Load);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
