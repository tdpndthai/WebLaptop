using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop.Models;
using WebLaptop_Model.Models;
using WebLaptop_Service;

namespace WebLaptop.Controllers
{
    public class ContactController : Controller
    {
        IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService)
        {
            _contactDetailService = contactDetailService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactvm = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return View(contactvm);
        }
    }
}