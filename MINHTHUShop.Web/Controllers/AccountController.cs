using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class AccountController : Controller
    {
        
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

/*        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng")]
        public ActionResult Register(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customerByEmail = _tb_CustomerService.GetByEmail(model.Email);
                    if (customerByEmail != null)
                    {
                        ModelState.AddModelError("email", "Email đã tồn tại!");
                        return View(model);
                    }
                    var newCustomer = new Tb_Customer()
                    {
                        Email = model.Email,
                        Password = GetMD5(model.Password),
                        Name = model.Name,
                        Phone = model.Phone,
                        Address = model.Address,
                        CreateDate = DateTime.Now
                    };

                    _tb_CustomerService.Create(newCustomer);
                    _tb_CustomerService.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                string content = System.IO.File.ReadAllText(Server.MapPath("/Content/Client/template/register_template.html"));
                content = content.Replace("{{Name}}", model.Name);
                content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink") + "dang-nhap.html");
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Đăng ký thành công!", content);

                ViewData["SuccessMsg"] = "Đăng ký thành công";
            }

            return View();
        }
*/
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}