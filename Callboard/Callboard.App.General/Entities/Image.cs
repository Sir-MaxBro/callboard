using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.General.Entities
{
    public class Image
    {
        public int ID { get; set; }

        public byte[] Data { get; set; }

        public string MimeType { get; set; }
    }
}
