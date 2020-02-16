using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TisKis.Models
{
    public class ConvertedImage
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public UserHistory UserHistory { get; set; }
    }
}
