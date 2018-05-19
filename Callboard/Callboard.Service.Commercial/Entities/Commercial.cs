using System.Runtime.Serialization;

namespace Callboard.Service.Commercial
{
    [DataContract]
    public class Commercial
    {
        [DataMember]
        public Image Image { get; set; }
    }
}
