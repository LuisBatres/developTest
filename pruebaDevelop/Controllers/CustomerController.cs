using Microsoft.AspNetCore.Mvc;
using pruebaDevelop.Models;
using RestSharp;
using System.Reflection;

namespace pruebaDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("CustomerInformation")]
        public async Task<Customer> GetCustomerInfo()
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get
            };
        }// dar de alta, duplicar y respaldar de bancos


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
