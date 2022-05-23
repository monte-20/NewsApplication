using FileWorxObjects;
using FileWorxWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsBusinessController : Controller
    {
        
        public  async Task<ActionResult> Index()
        {
            clsBusinessQuery business = new clsBusinessQuery();
            var list = await business.run();
            clsBusinessViewModel model=new clsBusinessViewModel();
            model.filter = business.Filter;
            model.list = list;
            return View(model);
        }

        [HttpPost]
        public  async Task<ActionResult> Index(clsBusinessFilter filter)
        {
            clsBusinessQuery business = new clsBusinessQuery();
            business.Filter = filter;
            var list = await business.run();
            clsBusinessViewModel model = new clsBusinessViewModel();
            model.filter = business.Filter;
            model.list = list;
            return View(model);
        }


        public async Task<ActionResult> Delete(string id)
        {
            try
            {

                Guid.TryParse(id, out Guid guid);
                clsBusiness business = new clsBusiness()
                {
                    ID = guid,
                };
                await business.Delete();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }



    }
}
