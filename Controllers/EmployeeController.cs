using Employee_Management_Application.Request;
using Employee_Management_Application.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Employee_Management_Application.StaticModel;
using System.Threading.Tasks;
using Employee_Management_Application.BAL;
using Microsoft.Extensions.Logging;

namespace Employee_Management_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly EmployeeBAL _employeeBAL;

        public EmployeeController(EmployeeBAL employeeBAL)
        {
            _employeeBAL = employeeBAL;
        }

        [HttpPost]
        public IActionResult Insert([FromForm] InsertRequest request)
        {
            var result = "";
            try
            {
                result = _employeeBAL.Insert(request);

            }
            catch (Exception ex)
            {
                return BadRequest(Message.InsertFailure);
            }

            if (!result.Equals(StatusType.Ok))
            {
                return BadRequest(result);
            }
            return Ok(Message.InsertSuccess);
        }

        [HttpGet("{id}")]
        public IActionResult SelectByID(int id)
        {

            EmployeeResponse employeeResponse = new EmployeeResponse();
            string failureMessage = "";
            try
            {
                employeeResponse = _employeeBAL.SelectByID(id , out failureMessage);

            }
            catch (Exception ex)
            {
                return BadRequest("Data Not Found");
            }

            if (!failureMessage.Equals(StatusType.Ok))
            {
                return BadRequest("Data Not Found");
            }
            return Ok(employeeResponse);
        }

        [HttpPut]
        public IActionResult Update([FromForm] UpdateRequest request)
        {
            var result = "";
            try
            {
                result = _employeeBAL.Update(request);

            }
            catch (Exception ex)
            {
                return BadRequest(Message.UpdateFailure);
            }

            if (!result.Equals(StatusType.Ok))
            {
                return BadRequest(result);
            }
            return Ok(Message.UpdateSuccess);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = "";
            try
            {
                result = _employeeBAL.Delete(id);

            }
            catch (Exception ex)
            {
                return BadRequest(Message.DeleteFail);
            }

            if (!result.Equals(StatusType.Ok))
            {
                return BadRequest(result);
            }
            return Ok(Message.DeleteSuccess);
        }

        [HttpPost("search")]
        public IActionResult Search([FromForm] SearchRequest request)
        {
            var employees = _employeeBAL.SearchEmployeeByFilter(request);
            if(employees == null)
            {
                return NotFound("Data Not Found");
            }

            return Ok(employees);
        }

    }
}
