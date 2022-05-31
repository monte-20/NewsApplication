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
            var table = new clsTableModel(list);
            clsFileViewModel model = new clsFileViewModel();
            model.filter = file.Filter;
            model.table = table;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(clsFileFilter filter)
        {
            clsFileQuery file = new clsFileQuery();
            file.Filter = filter;
            var list = await file.run();
            var table = new clsTableModel(list);
            clsFileViewModel model = new clsFileViewModel();
            model.filter = file.Filter;
            model.table = table;
            return View(model);
        }

        public  ActionResult Details(string id,string classID)
        {
            int.TryParse(classID, out int type);
            Guid.TryParse(id,out Guid guid);
            if (type == 1)
            {
               
                return  RedirectToAction("Details","clsNews" ,new {id=guid });
            }else if(type == 2)
            {
                return RedirectToAction("Details","clsPhoto", new { id = guid });
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id, string classID)
        {
            int.TryParse(classID, out int type);
            Guid.TryParse(id, out Guid guid);
            if (type == 1)
            {

                return RedirectToAction("Delete", "clsNews", new { id = guid });
            }
            else if (type == 2)
            {
                return RedirectToAction("Delete", "clsPhoto", new { id = guid });
            }
            return RedirectToAction("Index");

        }
    }
}
