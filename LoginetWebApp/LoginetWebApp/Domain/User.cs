using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LoginetWebApp.Domain
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [XmlIgnore]
        [JsonIgnore]
        public string Email { get; set; }
    }
}