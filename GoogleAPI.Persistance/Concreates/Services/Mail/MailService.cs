using GooleAPI.Application.Abstractions.IServices.IMail;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GoogleAPI.Persistance.Concreates.Services.Mail
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(List<string> addressList, string subject, string body, bool isBodyHtml)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = isBodyHtml;
            foreach (string address in addressList)
                mail.To.Add(address);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(_configuration["Mail:UserName"], _configuration["Company:Description"], Encoding.UTF8);


            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(
                _configuration["Mail:UserName"],
                _configuration["Mail:Password"]
            );
            client.EnableSsl = true;
            await client.SendMailAsync(mail);


        }

        public async Task SendPasswordResetEmail(string email, string userId, string resetToken)
        {

            var returnUrl = $"{_configuration["Company:AdminPassowordResetUrl"]}/{userId}/{resetToken}";
            var mail = await File.ReadAllTextAsync("C://code//resetPasswordEmail.txt");
            mail = mail.Replace("[LOGOURL]", _configuration["Company:LogoUrl"]).Replace("[WEBSITEURL]", _configuration["Company:WebSiteUrl"]).Replace("[RETURNURL]", returnUrl);
            await SendMail(new List<string>() { email }, "Şifre Yenileme Talebi", mail, true);


        }
    }
}
