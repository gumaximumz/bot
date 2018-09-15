using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingService.Interfaces;
using WebApi.Controllers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ApiController
    {
        private IClassService _service;

        public ValuesController(IClassService service)
        {
            _service = service;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var model = _service.Get(1);
            return ResultRequest(model);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _service.Get(id);
            return ResultRequest(model);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return SuccessRequest();
            }
            catch (Exception)
            {
                return ServerError();
            }
        }
    }
}
