using Newtonsoft.Json;

namespace pruebaDevelop.Models
{
    public class Address
    {
        [JsonProperty("address1")]
        public string? Address1 { get; set; }

        [JsonProperty("address2")]
        public string? Address2 { get; set; }

        [JsonProperty("addressId")]
        public string? AddressId { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("companyName")]
        public string? CompanyName { get; set; }

        [JsonProperty("countryCode")]
        public string? CountryCode { get; set; }

        [JsonProperty("creationDate")]
        public string? CreationDate { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("jobTitle")]
        public string? JobTitle { get; set; }

        [JsonProperty("lastModified")]
        public string? LastModified { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }

        [JsonProperty("postBox")]
        public string? PostBox { get; set; }

        [JsonProperty("preferred")]
        public string? Preferred { get; set; }

        [JsonProperty("salutation")]
        public string? Salutation { get; set; }

        [JsonProperty("secondName")]
        public string? SecondName { get; set; }

        [JsonProperty("stateCode")]
        public string? StateCode { get; set; }

        [JsonProperty("suite")]
        public string? Suite { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("c_esFiscal")]
        public string? C_esFiscal { get; set; }

        [JsonProperty("c_razonSocial")]
        public string? C_razonSocial { get; set; }

        [JsonProperty("c_rfc")]
        public string? C_rfc { get; set; }

        [JsonProperty("c_usoCFDI")]
        public string? C_usoCFDI { get; set; }

        [JsonProperty("c_colonia")]
        public string? C_colonia { get; set; }

        [JsonProperty("c_streetNumber")]
        public string? C_streetNumber { get; set; }

        [JsonProperty("c_buildingNumber")]
        public string? C_buildingNumber { get; set; }

        [JsonProperty("c_latitude")]
        public string? C_latitude { get; set; }

        [JsonProperty("c_longitude")]
        public string? C_longitude { get; set; }

        [JsonProperty("c_reference")]
        public string? C_reference { get; set; }

        [JsonProperty("errorMessage")]
        public string? ErrorMessage { get; set; }
    }
}
