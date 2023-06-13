using BotDetect.Web.Mvc;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Extensions;
using MINHTHUShop.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private ITb_FeedbackService _tb_FeedbackService;

        public FeedbackController(ITb_FeedbackService tb_FeedbackService)
        {
            this._tb_FeedbackService = tb_FeedbackService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            FeedbackVM viewModel = new FeedbackVM();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "FeedbackCaptcha", "Mã CAPTCHA không chính xác!")]
        public ActionResult SendFeedback(FeedbackVM feedbackVM)
        {
            if (ModelState.IsValid)
            {
                Tb_Feedback newFeedback = new Tb_Feedback();
                newFeedback.UpdateFeedback(feedbackVM);
                newFeedback.IsRead = false;
                newFeedback.CreateDate = DateTime.Now;

                _tb_FeedbackService.Create(newFeedback);
                _tb_FeedbackService.SaveChanges();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công!";

                //send confirmation email
/*                string emailSubject = "Xác nhận gửi phản hồi thành công";
                string username = feedbackVM.Name;
                string emailMessage = "Xin chào " + username + ", \n" +
                    "Chúng tôi đã nhận được thông tin phản hồi từ bạn. Sự hài lòng của bạn luôn là ưu tiên số một đối với chúng tôi. Chúng tôi sẽ liên lạc với bạn trong thời gian sớm nhất.\n" +
                    "Chúc bạn có một ngày gặp thập nhiều điều may mắn và tốt đẹp.\n" +
                    "(Hãy cho chúng tôi biết nếu bạn có thêm bất kỳ câu hỏi, ý kiến, quan tâm hoặc góp ý đến cửa hàng)\n" +
                    "Người gửi,\n" +
                    "Cửa hàng Minh Thư\n\n" +
                    "Dưới đây là nội dung phản hồi của bạn gửi tới cửa hàng:\n" +
                    "\"" + feedbackVM.Message + "\"";
                EmailSender emailSender = new EmailSender();
                await emailSender.SendEmail(emailSubject, feedbackVM.Email, username, emailMessage);
*/            }

            //sau khi gửi phản hồi thành công thì trả về rỗng
            feedbackVM.Name = "";
            feedbackVM.Email = "";
            feedbackVM.Phone = "";
            feedbackVM.Message = "";

            return View("Index", feedbackVM);
        }
    }
}