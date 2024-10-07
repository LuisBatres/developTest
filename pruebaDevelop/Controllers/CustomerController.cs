using Microsoft.AspNetCore.Mvc;
using pruebaDevelop.APIs;
using pruebaDevelop.Models;
using pruebaDevelop.Utils;
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

            CustomerAPI customerAPI = new CustomerAPI();
            //Consumimos el servicio
            RestResponse restResponse = await customerAPI.CustomerConsumme();

            if (restResponse.Content == null) return new Customer();

            // Obtenemos el modelo cliente
            Customer? customerResponse = CustomerUtils.FormatJsonAndObtainCustomer(restResponse);

            if (customerResponse == null) return new Customer();

            return customerResponse;
        }

        // --------------------------------------------------------------------------------------------------
        // Servicio que ordene las direcciones (en base a la propiedad Address1)
        // y por fecha de creación (CreationDate),
        // haciendo posible que el usuario pueda seleccionar con qué propiedad ordenar y en qué orden.
        [HttpGet]
        [Route("SortAddresses")]
        public async Task<List<Address>> SortAddress(string property, string order)
        {
            RestResponse restResponse = await new CustomerAPI().CustomerConsumme();

            if (restResponse.Content == null) return new List<Address>();

            Customer? customerResponse = CustomerUtils.FormatJsonAndObtainCustomer(restResponse);

            if (customerResponse == null) return new List<Address>();

            List<Address> sortedList = CustomerUtils.OrderCustomerAddressList(property, order, customerResponse);

            if (sortedList.Count == 0) return new List<Address>();

            return sortedList;
        }

        // --------------------------------------------------------------------------------------------------
        // Servicio que retorne la dirección preferida del cliente.
        // (En base a la propiedad “preferred” de la lista “address”).
        [HttpGet]
        [Route("PreferredAddress")]
        public async Task<Address> PreferredAddress([FromHeader] string customerId)
        {
            RestResponse restResponse = await new CustomerAPI().CustomerConsumme();

            if (restResponse.Content == null) return new Address();

            Customer? customerResponse = CustomerUtils.FormatJsonAndObtainCustomer(restResponse);

            var id = customerResponse.CustomerId.ToString();

            var address = (from customer in customerResponse.ToString()
                           where id == customerId
                           from addr in customerResponse.Addresses
                           where (bool)addr.Preferred == true
                           select addr).FirstOrDefault();

            if(address == null) return new Address();

            return address;

        }

        // --------------------------------------------------------------------------------------------------
        // Servicio para buscar todas direcciones del cliente por código postal.
        [HttpGet]
        [Route("SearchAddressByPostalCode")]
        public async Task<List<Address>> SearchAddress([FromQuery] string postalCode)
        {
            RestResponse restResponse = await new CustomerAPI().CustomerConsumme();

            if (restResponse.Content == null) return new List<Address>();

            Customer? customer = CustomerUtils.FormatJsonAndObtainCustomer(restResponse);

            // Busca todas las direcciones con el mismo codigo postal y las guarda en una lista
            List<Address> direcciones = customer.Addresses.FindAll(d => d.PostalCode == postalCode);

            if (direcciones.Count == 0) return new List<Address>();

            // Devolvemos una lista con todas las direcciones que tienen un mismo codigo postal
            return direcciones;
        }
    }
}
