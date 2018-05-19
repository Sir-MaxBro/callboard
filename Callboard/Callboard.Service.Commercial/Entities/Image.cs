using System.Runtime.Serialization;

namespace Callboard.Service.Commercial
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public byte[] Data { get; set; }

        [DataMember]
        public string Extension { get; set; }
    }
}
