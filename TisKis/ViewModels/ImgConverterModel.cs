using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TisKis.ViewModels
{
    public class ImgConverterModel
    {
        public byte[] TempUploadImage { get; set; }
        public byte[] TempConvertedImage { get; set; }
        public int ParamAction { get; set; }
    }
}
