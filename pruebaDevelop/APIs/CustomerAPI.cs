using RestSharp;

namespace pruebaDevelop.APIs
{
    public class CustomerAPI
    {
        // Peticion
        public async Task<RestResponse> CustomerConsumme()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = "https://examentecnico.azurewebsites.net/v3/api/Test/Customer",
                Method = Method.Get
            };

            restRequest.AddHeader("Authorization", "Basic Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4=");

            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            // Obtiene un json escapado

            return restResponse;
        }
    }
}
