using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebLaptop.App_Start;
using WebLaptop.Models;
using WebLaptop_Common;
using WebLaptop_Model.Models;

namespace WebLaptop.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCaptcha", "Wrong Captcha!")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userEmail != null)
                {
                    ModelState.AddModelError("emaul", "Email đã tồn tại");
                    return View(model);
                }
                var userByUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("account", "Tài khoản đã tồn tại");
                    return View(model);
                }
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    FullName = model.FullName
                };
                await  _userManager.CreateAsync(user, model.PassWord);
                var adminUser = await _userManager.FindByEmailAsync(model.Email);

                if (adminUser != null)
                {
                     await _userManager.AddToRolesAsync(adminUser.Id.ToString(), new string[] { "User" });
                }
                TempData["Success"] = "Đăng ký thành công";
                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/register_teamplate.html"));
                content = content.Replace("{{UserName}}", model.FullName);
                content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink")+"dang-nhap.html");
                //nên thay adminEmail thành email vừa đăng ký,cái này là để test
                var adminEmail = ConfigHelper.GetByKey("AdminUser");
                MailHelper.SendMail(adminEmail, "Đăng ký tài khoản thành công", content);
            }
            return View();
        }
    }
}