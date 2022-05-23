using FileWorxObjects;
using FileWorxWebApp.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsFileController : Controller
    {
        // GET: File
        public async Task<ActionResult> Index()
        {
            clsFileQuery file = new clsFileQuery();
            var list = await file.run();
            clsFileViewModel model = new clsFileViewModel();
            model.filter = file.Filter;
            model.list = list;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(clsFileFilter filter)
        {
            clsFileQuery file = new clsFileQuery();
            file.Filter = filter;
            var list = await file.run();
            clsFileViewModel model = new clsFileViewModel();
            model.filter = file.Filter;
            model.list = list;
            return View(model);
        }

        public  ActionResult Details(string id,string classID)
        {
            int.TryParse(classID, out int type);
            Guid.TryParse(id,out Guid guid);
            if (type == 1)
            {
               
                return  RedirectToAction("newsDetails","clsNews" ,new {id=guid });
            }else if(type == 2)
            {
                return RedirectToAction("photoDetails","clsPhoto", new { id = guid });
            }
            return RedirectToAction("Index");
        }
      
       
        public async Task<ActionResult> Delete(string id)
        {
            try
            {

                Guid.TryParse(id, out Guid guid);
                clsFile file = new clsFile()
                {
                    ID = guid,
                };
                await file.Delete();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
