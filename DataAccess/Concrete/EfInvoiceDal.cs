using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace DataAccess.Concrete
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, MarryUsContext>, IInvoiceDal
    {
        public void SendInvoice(InvoiceDto invoice)
        {
            SendEmail();
        }
        private bool SendEmail()
        {
            try
            {
                // E-posta gönderme işlemleri
                // E-posta gönderim için gerekli bilgileri ayarlayın
                string senderEmail = "batuhan3248@hotmail.com";
                string senderPassword = "159951753357";
                string recipientEmail = "asansimay3@gmail.com";
                string subject = "Test E-postası";
                string body = "<h1>Merhaba, bu bir test e-postasıdır!</h1>";

                // SMTP istemcisini oluşturun
                using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtpClient.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                    smtpClient.Authenticate(senderEmail, senderPassword);

                    // E-posta mesajını oluşturun
                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress("Marry US",senderEmail));
                    emailMessage.To.Add(new MailboxAddress("DEĞERLİ ÇİFTİMİZ",recipientEmail));
                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart("html") { Text = body };

                    // E-postayı gönderin
                    smtpClient.Send(emailMessage);
                    smtpClient.Disconnect(true);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
