using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TisKis.Data;
using TisKis.ImgConvert;
using TisKis.Models;
using TisKis.ViewModels;

namespace TisKis.Controllers
{
    public class EditorController : Controller
    {
        private ApplicationDbContext dbContext { get; set; }
        private UserManager<User> manager { get; set; }

        public EditorController(ApplicationDbContext dbContext, UserManager<User> manager)
        {
            this.dbContext = dbContext;
            this.manager = manager;
        }

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
        public async System.Threading.Tasks.Task<IActionResult> SaveImgAsync(ImgConverterModel model)
        {
            var user = await manager.FindByNameAsync(User.Identity.Name);
            var uploadImg = new UploadImage() { Img = model.TempUploadImage};
            var convertedImg = new ConvertedImage() { Img = model.TempConvertedImage};

            await dbContext.UploadImages.AddAsync(uploadImg);
            await dbContext.ConvertedImages.AddAsync(convertedImg);
            await dbContext.SaveChangesAsync();

            var historyStr = new UserHistory()
            {
                ConvertedImage = convertedImg,
                UploadImage = uploadImg,
                User = user
            };

            await dbContext.UserHistories.AddAsync(historyStr);
            await dbContext.SaveChangesAsync();

            user.UserHistories.Add(historyStr);
            await dbContext.SaveChangesAsync();

            return File(model.TempConvertedImage, "image/jpeg", "ConvertedImage(TisKis).jpeg");
        }
    }
}