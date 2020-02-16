using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TisKis.ImgConvert;
using TisKis.ViewModels;

namespace TisKis.Controllers
{
    public class EditorController : Controller
    {
        [HttpPost]
        public IActionResult Index(IFormFile uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] uploadImageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.OpenReadStream()))
                {
                    uploadImageData = binaryReader.ReadBytes((int)uploadImage.Length);
                }

                ImgConverterModel model = new ImgConverterModel()
                {
                    TempConvertedImage = uploadImageData,
                    TempUploadImage = uploadImageData
                };

                return View(model);
            }

            return View(new ImgConverterModel());
        }

        [HttpPost]
        public IActionResult Convert(ImgConverterModel model)
        {
            MemoryStream imgData = new MemoryStream(model.TempUploadImage);

            Bitmap img = BW.rgb_bw((Bitmap)Bitmap.FromStream(imgData), model.ParamAction);

            imgData.Dispose();

            MemoryStream convertedImgData = new MemoryStream();
            img.Save(convertedImgData, ImageFormat.Jpeg);

            model.TempConvertedImage = convertedImgData.ToArray();

            convertedImgData.Dispose();

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult SaveImg(ImgConverterModel model)
        {
            return File(model.TempConvertedImage, "image/jpeg", "ConvertedImage(TisKis).jpeg");
        }
    }
}