using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Web.App_Start;
using MINHTHUShop.Web.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

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

        public AccountController()
        {
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Tb_User user = _userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    user.IsLoggedIn = true;
                    user.LastLogin = DateTime.Now;
                    _userManager.Update(user);
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Tb_User user = _userManager.FindByName(User.Identity.Name);
            user.IsLoggedIn = false;
            user.LastLogin = DateTime.Now;
            _userManager.Update(user);
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã Captcha không chính xác!")]
        public async Task<ActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userByEmail != null)
                {
                    ModelState.AddModelError("email", "Email đã tồn tại!");
                    return View(model);
                }
                var userByUserName = await _userManager.FindByNameAsync(model.UserName);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("username", "Tên tài khoản đã tồn tại!");
                    return View(model);
                }
                var user = new Tb_User()
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Email = model.Email,
                    EmailConfirmed = true,
                    PhoneNumber = model.Phone,
                    Address = model.Address,
                    CreateDate = DateTime.Now,
                    Status = true
                };

                await _userManager.CreateAsync(user, model.Password);

                //Thêm quyền user
                var adminUser = await _userManager.FindByEmailAsync(model.Email);
                if (adminUser != null)
                    await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "Khách hàng" });

                //send confirmation email
                string emailSubject = "Xác nhận gửi phản hồi thành công";
                string username = model.Name;
                string emailMessage = "Xin chào " + username + ", \n" +
                    "Cảm ơn bạn đã đăng ký thành viên trên website cửa hàng. Sự hài lòng của bạn luôn là ưu tiên số một đối với chúng tôi.\n" +
                    "Chúc bạn có một ngày mua sắm thật vui vẻ và nhiều năng lượng!\n" +
                    "Người gửi,\n" +
                    "Cửa hàng Minh Thư\n";
                EmailSender emailSender = new EmailSender();
                await emailSender.SendEmail(emailSubject, model.Email, username, emailMessage);

                ViewData["SuccessMsg"] = "Đăng ký thành công";
            }

            return View();
        }
    }
}