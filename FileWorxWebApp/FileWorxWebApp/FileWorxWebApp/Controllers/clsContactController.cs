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
            clsContactQuery contacts = new clsContactQuery();
            var list = await contacts.run();
            clsContactViewModel model = new clsContactViewModel();
            model.filter = contacts.Filter;
            model.list = list;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(clsContactFilter filter)
        {
            clsContactQuery contacts = new clsContactQuery();
            contacts.Filter = filter;
            var list = await contacts.run();
            clsContactViewModel model = new clsContactViewModel();
            model.filter = contacts.Filter;
            model.list = list;
            return View(model);
        }

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

        public ActionResult Create()
        {
            return View();
        }

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
