using System;
using System.Xml.Serialization;

namespace LoginetWebApp.LoginetWebServiceTypes
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class GetUserAlbumsRequest
        : RequestBase
    {
        public int UserId { get; set; }
    }
}