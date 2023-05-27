using AutoMapper;
using BotDetect.Web.Mvc;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Extensions;
using MINHTHUShop.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class AboutController : Controller
    {
        private ITb_AboutService _tb_AboutService;
        private ITb_FeedbackService _tb_FeedbackService;

        public AboutController(ITb_AboutService tb_AboutService, ITb_FeedbackService tb_FeedbackService)
        {
            this._tb_AboutService = tb_AboutService;
            this._tb_FeedbackService = tb_FeedbackService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            FeedbackVM viewModel = new FeedbackVM();
            viewModel.AboutVMs = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "aboutCaptcha", "Mã CAPCHA không đúng!")]
        public ActionResult SendFeedback(FeedbackVM feedbackVM)
        {
            if (ModelState.IsValid)
            {
                Tb_Feedback newFeedback = new Tb_Feedback();
                newFeedback.UpdateFeedback(feedbackVM);

                _tb_FeedbackService.Create(newFeedback);
                _tb_FeedbackService.SaveChanges();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công!";

                string content = System.IO.File.ReadAllText(Server.MapPath("/Content/Client/template/about_template.html"));
                
                content = content.Replace("{{Customer.Name}}", feedbackVM.CustomerVM.Name);
                content = content.Replace("{{Customer.Email}}", feedbackVM.CustomerVM.Email);
                content = content.Replace("{{Message}}", feedbackVM.Message);
                
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                //sau khi gửi phản hồi thành công thì trả về rỗng
                feedbackVM.Message = "";
            }
            feedbackVM.AboutVMs = GetDetail();

            return View("Index", feedbackVM);
        }

        private IEnumerable<AboutVM> GetDetail()
        {
            var model = _tb_AboutService.GetDefaultAbout();
            var aboutVM = Mapper.Map<IEnumerable<Tb_About>, IEnumerable<AboutVM>>(model);
            return aboutVM;
        }
    }
}