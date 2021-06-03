using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult ContactSideBarPartial()
        {
            var contactList = cm.GetList();
            ViewBag.contactCount = contactList.Count();
            var listResult = mm.GetListSendbox();
            ViewBag.sendCount = listResult.Count();
            var listResult2 = mm.GetListInbox();
            ViewBag.inboxCount = listResult2.Count();

            var drafList = listResult.FindAll(x => x.isDraft == true);
            ViewBag.draftCount =  drafList.Count();
            return PartialView();
        }
    }
}