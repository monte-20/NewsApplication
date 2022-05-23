using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsPhotoController : Controller
    {


        public ActionResult CreatePhoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePhoto(clsPhotos photo, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string pic = Path.GetFileName(file.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/Photos/"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                    photo.Photo = path;
                }
                await photo.Update();

                return RedirectToAction("Index", "clsFile");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> PhotoDetails(Guid id)
        {

            clsPhotos photos = new clsPhotos()
            {
                ID = id,
            };
            await photos.Read();
            return View(photos);
        }

        public async Task<ActionResult> EditPhoto(string id)
        {
            Guid.TryParse(id, out Guid guid);
            clsPhotos photo = new clsPhotos()
            {
                ID = guid,
            };
            await photo.Read();
            return View(photo);
        }

        [HttpPost]
        public async Task<ActionResult> EditPhoto(clsPhotos photo)
        {
            try
            {
                await photo.Update();

                return RedirectToAction("Index", "clsFile");
            }
            catch
            {
                return View();
            }
        }

    }
}