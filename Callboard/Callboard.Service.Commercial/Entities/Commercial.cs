using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Callboard.Service.Commercial
{
    [DataContract]
    public class Commercial
    {
        [DataMember]
        public byte[] ImageData { get; set; }

        [DataMember]
        public string ImageMimeType { get; set; }
    }
}
