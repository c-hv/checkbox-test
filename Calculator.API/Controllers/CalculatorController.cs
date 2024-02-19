using Calculator.API.Contracts;
using Calculator.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController(ICalculationService calculationService, IOperationsService operationsService)
        : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Calculate([FromBody] CalculationModel calculation)
        {
            try
            {
                return Ok(new { result = calculationService.Calculate(calculation) });
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("operations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetAvailableOperations()
        {
            try
            {
                return Ok(operationsService.GetAvailableOperations());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
