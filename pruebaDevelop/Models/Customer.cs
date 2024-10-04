using Newtonsoft.Json;

namespace pruebaDevelop.Models
{
    public class Customer
    {
        // customerId, Email, Teléfono, Direcciones, Fecha de cumpleaños, Nombre y Apellido.

        [JsonProperty("customerId")]
        public string? CustomerId { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phoneHome")]
        public string? PhoneHome { get; set; }

        [JsonProperty("phoneMobile")]
        public string? PhoneMobile { get; set; }

        [JsonProperty("addresses")]
        public List<Address>? Addresses { get; set; }

        [JsonProperty("birthday")]
        public string? Birthday { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }
    }
}
