using System;
using System.Xml.Serialization;
using LoginetWebApp.Domain;

namespace LoginetWebApp.LoginetWebServiceTypes
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class GetUserAlbumsResponse
        : ResponseBase
    {
        public Album[] Albums { get; set; }
    }
}