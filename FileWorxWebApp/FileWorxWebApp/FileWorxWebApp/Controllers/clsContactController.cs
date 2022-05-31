using FileWorxObjects;
using FileWorxWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsContactController : Controller
    {
        public async Task<ActionResult> Index()
        {
            clsContactQuery user = new clsContactQuery();
            var list = await user.run();
            clsBusinessViewModel model = new clsBusinessViewModel();
            model.filter = user.Filter;
            model.list = list;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(clsBusinessFilter filter)
        {
            clsContactQuery user = new clsContactQuery();
            user.Filter = filter;
            var list = await user.run();
            clsBusinessViewModel model = new clsBusinessViewModel();
            model.filter = user.Filter;
            model.list = list;
            return View(model);
        }

        // GET: User/Details/5
        public async  Task<ActionResult> Details(string id)
        {
            Guid.TryParse(id, out Guid guid);
            clsContact contact =new clsContact() 
            { 
            ID=guid
            };
            await contact.Read();
            return View(contact);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(clsContact contact)
        {
            try
            {
                await contact.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            Guid.TryParse(id, out Guid guid);
            clsContact contact = new clsContact()
            {
                ID = guid
            };
            await contact.Read();
            return View(contact);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(clsContact contact)
        {
            try
            {
                await contact.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            try
            {

                Guid.TryParse(id, out Guid guid);
                clsContact contact = new clsContact()
                {
                    ID = guid,
                };
                await contact.Delete();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

     
    }
}
