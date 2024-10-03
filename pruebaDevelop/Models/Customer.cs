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

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("address")]
        public List<Address>? Addresses { get; set; }

        [JsonProperty("birthday")]
        public string? Birthday { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }
    }
}
