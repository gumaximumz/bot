using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult ServerError()
        {
            return BadRequest(new ResponseModel() { Code = "02", Message = "Server error." });
        }

        public IActionResult ServerError(string code, string message)
        {
            return BadRequest(new ResponseModel() { Code = code, Message = message });
        }

        public IActionResult SuccessRequest()
        {
            return new OkObjectResult(new ResponseModel() { Code = "00", Message = "Success" });
        }

        public IActionResult ResultRequest<T>(T model)
        {
            return new ObjectResult(new ResponseModel<T>
            {
                Code = "00",
                Message = "Success",
                Data = model
            });
        }

        public IActionResult ValidResponse(ModelStateDictionary modelStates)
        {
            var response = new ResponseModel();

            foreach (var modelState in modelStates)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    var detail = new ResponseDetail
                    {
                        Code = "01",
                        Message = error.ErrorMessage == "" ? error.Exception.Message : error.ErrorMessage
                    };

                    response.Details.Add(detail);
                }
            }

            response.Code = "01";
            response.Message = "Field is required";

            return BadRequest(response);
        }
    }
}