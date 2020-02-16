using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TisKis.Models
{
    public class UserHistory
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public UploadImage UploadImage { get; set; }
        public int? UploadImageId { get; set; }
        public ConvertedImage ConvertedImage { get; set; }
        public int? ConvertedImageId { get; set; }
    }
}
