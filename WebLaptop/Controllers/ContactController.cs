using AutoMapper;
using BotDetect.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop.Infrastructure.Extensions;
using WebLaptop.Models;
using WebLaptop_Common;
using WebLaptop_Model.Models;
using WebLaptop_Service;

namespace WebLaptop.Controllers
{
    public class ContactController : Controller
    {
        IContactDetailService _contactDetailService;
        IFeedbackService _feedbackService;

        public ContactController(IContactDetailService contactDetailService,IFeedbackService feedbackService)
        {
            _contactDetailService = contactDetailService;
            _feedbackService = feedbackService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetailViewModel = GetDetail();
            return View(viewModel);
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "ContactCaptcha", "Wrong Captcha!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback();
                feedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(feedback);
                _feedbackService.Save();
                TempData["Success"] = "Gửi phản hồi thành công";
                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var adminEmail = ConfigHelper.GetByKey("AdminUser");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);
            }
            feedbackViewModel.ContactDetailViewModel = GetDetail();
            return RedirectToAction("Index");
        }

        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactvm = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactvm;
        }
    }
}