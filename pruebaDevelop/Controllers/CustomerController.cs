using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pruebaDevelop.Models;
using RestSharp;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

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
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,
            };

            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");

            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            //text

            if (restResponse.Content == null)
                return new Customer();

            //se deserializa la respuesta  
            string? desResponse = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            JToken token = JToken.Parse(desResponse);
            JObject json = JObject.Parse((string)token);

            if (json == null)
                return new Customer();

            //tenemos el JSON y convertimos en objeto de utilidad
            Customer? customerResponse = JsonConvert.DeserializeObject<Customer>(json.ToString());
            //ya tenemos respuesta

            if (customerResponse == null) 
                return new Customer();
            
            return customerResponse;
        }

        [HttpGet]
        [Route("SortAddresses")]
        public async Task<Customer> SortAddressesBy([FromQuery] string nombre)
        {

        }

        [HttpGet]
        [Route("PreferedAddress")]
        public async Task<Customer> PreferedAddress([FromQuery] string customer)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get,
            };

            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");

            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            //text

            if (restResponse.Content == null)
                return new Customer();

            //se deserializa la respuesta  
            string? desResponse = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            JToken token = JToken.Parse(desResponse);
            JObject json = JObject.Parse((string)token);

            if (json == null)
                return new Customer();

            //tenemos el JSON y convertimos en objeto de utilidad
            Address? addressResponse = JsonConvert.DeserializeObject<Address>(json.ToString());
            //ya tenemos respuesta

            if (addressResponse == null)
                return new Customer();


            //return customerResponse;
        }
    }
