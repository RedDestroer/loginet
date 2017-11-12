using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LoginetWebApp.Domain
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class Album
    {
        //[JsonProperty("id")]
        public int Id { get; set; }

        //[JsonProperty("userId")]
        public int UserId { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }
    }
}