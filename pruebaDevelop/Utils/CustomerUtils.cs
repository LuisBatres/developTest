using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pruebaDevelop.Models;
using RestSharp;

namespace pruebaDevelop.Utils
{
    public static class CustomerUtils
    {
        public static Customer? FormatJsonAndObtainCustomer(RestResponse restResponse)
        {
            // Deserializamos el contenido de la respuesta del consumo y lo convierte a string.
            string? desResponse = JsonConvert.DeserializeObject(restResponse.Content).ToString();

            // Aportacion de @Jon Skeet en stack overflow
            JToken token = JToken.Parse(desResponse); // Descapar
            JObject json = JObject.Parse((string)token); // Obtener el json

            // Convertimos en objeto de utilidad
            Customer? customer = JsonConvert.DeserializeObject<Customer>(json.ToString());
            
            // Devolvemos la respuesta en un objeto de cliente con la info del json
            return customer;
        }

        // Metodo para ordenar una lista de direcciones segun propiedad y orden
        public static List<Address> OrderCustomerAddressList(string property, string order, Customer? customerResponse)
        {
            string orderLower = order.ToLower();

            // Lista que contendra las direcciones del cliente
            List<Address> sortedList = customerResponse.Addresses;

            if (property == "address1" && orderLower == "desc")
            {
                sortedList = sortedList.OrderByDescending(a => a.Address1).ToList();
            }
            else if (property == "address1" && orderLower == "asc")
            {
                sortedList = sortedList.OrderBy(a => a.Address1).ToList();
            }
            else if (property == "creationDate" && orderLower == "desc")
            {
                sortedList = sortedList.OrderByDescending(a => a.CreationDate).ToList();
            }
            else if (property == "creationDate" && orderLower == "asc")
                sortedList = sortedList.OrderBy(a => a.CreationDate).ToList();
           
            // Devolvemos la lista ya ordenada
            return sortedList;
        }
    }
}
