using FileWorxObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsNewsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(clsNews news)
        {
            try
            {
                await news.Update();

                return RedirectToAction("Index","clsFile");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Details(Guid id)
        {
            clsNews news = new clsNews()
            {
                ID = id,
            };
            await news.Read();
            return View(news);
        }
        public async Task<ActionResult> Edit(string id)
        {
            Guid.TryParse(id, out Guid guid);
            clsNews news = new clsNews()
            {
                ID = guid,
            };
            await news.Read();
            return View(news);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(clsNews news)
        {
            try
            {
                await news.Update();

                return RedirectToAction("Index","clsFile");
            }
            catch
            {
                return View();
            }
        }
    }
}