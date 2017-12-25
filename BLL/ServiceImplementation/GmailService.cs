using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using System.Net.Mail;
using System.Net;

namespace BLL.ServiceImplementation
{
    public class GmailService : IMailService
    {
        public void SendMail(MailData data)
        {
            var result = this.ConfigureMail(data);
            var email = result.Item1;
            var smtp = result.Item2;
            smtp.Send(email);
        }

        public Task SendMailAsync(MailData data)
        {
            var result = this.ConfigureMail(data);
            var email = result.Item1;
            var smtp = result.Item2;
            return smtp.SendMailAsync(email);
        }

        private Tuple<MailMessage,SmtpClient> ConfigureMail(MailData data)
        {
            var from = new MailAddress(data.From);
            var to = new MailAddress(data.To);

            var email = new MailMessage(from, to);
            email.Subject = data.Subject;
            email.Body = data.Message;
            email.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(data.From, data.FromPassword);
            smtp.EnableSsl = true;

            return Tuple.Create(email, smtp);
        }
    }
}
