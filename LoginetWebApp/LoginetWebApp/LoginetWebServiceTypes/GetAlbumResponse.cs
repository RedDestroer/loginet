using System;
using System.Xml.Serialization;
using LoginetWebApp.Domain;

namespace LoginetWebApp.LoginetWebServiceTypes
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class GetAlbumResponse
        : ResponseBase
    {
        public Album Album { get; set; }
    }
}