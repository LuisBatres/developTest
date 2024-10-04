using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pruebaDevelop.Models;
using RestSharp;

namespace pruebaDevelop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // Servicio para obtener solo la información importante del cliente como:
        // customerId, Email, Teléfono, Direcciones, Fecha de cumpleaños, Nombre y Apellido.
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


        // Servicio que retorne la dirección preferida del cliente.
        // (En base a la propiedad “preferred” de la lista “address”).

        // Servicio para buscar direcciones del cliente por código postal.
        [HttpGet]
        [Route("SearchAddressByPostalCode")]
        public async Task<Address> SearchAddress([FromQuery] string postalCode)
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
                return new Address();

            //se deserializa la respuesta  
            string? desResponse = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            JToken token = JToken.Parse(desResponse);
            JObject json = JObject.Parse((string)token);

            if (json == null)
                return new Address();

            string? address = json["addresses"].Where(a => a[postalCode] == a["postalCode"]).Select(a => a["address1"].ToString()).FirstOrDefault();

            Address? addressResponse = JsonConvert.DeserializeObject<Address>(address.ToString());

            if (addressResponse == null)
                return new Address();

            return addressResponse;
        }
    }
}
