using System.Runtime.Serialization;

namespace Callboard.Service.Commercial
{
    [DataContract]
    public class Commercial
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Image Image { get; set; }
    }
}
