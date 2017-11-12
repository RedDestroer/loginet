using System;
using System.Xml.Serialization;

namespace LoginetWebApp.LoginetWebServiceTypes
{
    [Serializable]
    [XmlType(Namespace = LoginetWebService.XmlNs)]
    public class GetAlbumRequest
        : RequestBase
    {
        public int AlbumId { get; set; }
    }
}