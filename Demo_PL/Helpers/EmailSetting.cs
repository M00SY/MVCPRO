using Demo_Dal.Entities;

using System.Net;
using System.Net.Mail;



namespace Demo_PL.Helpers
{
    public class EmailSetting
    {

        public static void SendEmail(Email email)
        {

            var client = new SmtpClient("smtp.gmail.com", 587);
            //var client = new SmtpClient("smtp.ethereal.email", 587);

            client.EnableSsl = true;

            //client.Credentials = new NetworkCredential("anonymous194752@gmail.com", "ekisokdvoqwaqhpw");
            client.Credentials = new NetworkCredential("dasia.brekke83@ethereal.email", "3z95PKkX7RhaQvzsn6");

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("dasia.brekke83@ethereal.email");
            //mailMessage.From = new MailAddress("anonymous194752@gmail.com");
            mailMessage.To.Add(email.To);
            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Body;

            client.Send(mailMessage);

            //client.Send(
            //"dasia.brekke83@ethereal.email",
            //email.To,
            //email.Subject,
            //email.Body);
        }


    }
}
