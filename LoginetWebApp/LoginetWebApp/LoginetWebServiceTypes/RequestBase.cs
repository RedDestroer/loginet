using System;
using System.Xml.Serialization;

namespace LoginetWebApp.LoginetWebServiceTypes
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public abstract class RequestBase
    {
        public ResponseType ResponseType { get; set; }
    }
}