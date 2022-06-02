using FileWorxObjects;
using FileWorxWebApp.Models;
using FtpTransfer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileWorxWebApp.Controllers
{
    public class clsFileController : Controller
    {
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
      
     [HttpPost]
        public async Task<ActionResult> Transfer(clsTableModel table)
        {
            clsTranfereViewModel model = new clsTranfereViewModel();
            model.filesTable = table;
            clsContactQuery contacts = new clsContactQuery();
            var list = await contacts.run();
            var contactsTable = new clsTableModel(list);
            model.contactTable = contactsTable;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> TransferFiles(clsTableModel filesTable, clsTableModel contactTable)
        {
            clsTableConverter tableConverter= new clsTableConverter();
            List<clsFile> files = tableConverter.convertToFiles(filesTable);
            List<clsContact> contacts = tableConverter.convertToContacts(contactTable);
            clsFtpTransmitter transmitter= new clsFtpTransmitter();
            await transmitter.TransferFiles(contacts, files);
            return RedirectToAction("Index");
        }
    }
}
