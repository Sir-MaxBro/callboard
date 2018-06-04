using System.Runtime.Serialization;

namespace Callboard.Service.Commercial
{
    [DataContract]
    public class CommercialNotFound
    {
        [DataMember]
        public string Message { get; set; }
    }
}
