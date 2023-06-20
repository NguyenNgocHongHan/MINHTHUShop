using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace MINHTHUShop.Common
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string username, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("han.nnh.61cntt@ntu.edu.vn", "MINH THƯ Shop");
            var to = new EmailAddress(toEmail, username);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}