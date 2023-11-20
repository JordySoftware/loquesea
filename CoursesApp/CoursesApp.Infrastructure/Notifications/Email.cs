using System.Net;
using System.Net.Mail;

namespace CoursesApp.Infrastructure.Notifications
{
    public class Email
    {
        public static void SendMessage(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("FromMailAddress");
                message.To.Add(new MailAddress("ToMailAddress1"));
                message.To.Add(new MailAddress("ToMailAddress2"));
                message.Subject = "Test";
                message.IsBodyHtml = true;
                message.Body = htmlString;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
