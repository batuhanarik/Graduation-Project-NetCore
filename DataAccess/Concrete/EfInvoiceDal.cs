using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

using System.Net.Mail;
using Entities.DTOs;

using MailKit.Security;
using MimeKit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Concrete
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, MarryUsContext>, IInvoiceDal
    {
        public void SendInvoice(InvoiceDto invoice)
        {
            SendEmail();
        }


        private static bool SendEmail()
        {
            try
            {
               
                // E-posta gönderme işlemleri
                string senderEmail = "batuhan3248@hotmail.com";
                string senderPassword = "159951753357";
                string recipientEmail = "batuhanarik123@gmail.com";
                string subject = "Test E-postası";
                string body = "<table>\r\n  <tr>\r\n    <th>Company</th>\r\n    <th>Contact</th>\r\n    <th>Country</th>\r\n  </tr>\r\n  <tr>\r\n    <td>Alfreds Futterkiste</td>\r\n    <td>Maria Anders</td>\r\n    <td>Germany</td>\r\n  </tr>\r\n  <tr>\r\n    <td>Centro comercial Moctezuma</td>\r\n    <td>Francisco Chang</td>\r\n    <td>Mexico</td>\r\n  </tr>\r\n  <tr>\r\n    <td>Ernst Handel</td>\r\n    <td>Roland Mendel</td>\r\n    <td>Austria</td>\r\n  </tr>\r\n  <tr>\r\n    <td>Island Trading</td>\r\n    <td>Helen Bennett</td>\r\n    <td>UK</td>\r\n  </tr>\r\n  <tr>\r\n    <td>Laughing Bacchus Winecellars</td>\r\n    <td>Yoshi Tannamuri</td>\r\n    <td>Canada</td>\r\n  </tr>\r\n  <tr>\r\n    <td>Magazzini Alimentari Riuniti</td>\r\n    <td>Giovanni Rovelli</td>\r\n    <td>Italy</td>\r\n  </tr>\r\n</table>";

                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("e-fatura.pdf", FileMode.Create));
                document.Open();

                StringReader reader = new(body);
                HTMLWorker htmlWorker = new(document);
                htmlWorker.Parse(reader);

                document.Close();

                // SMTP istemcisini oluşturun
                using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtpClient.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                    smtpClient.Authenticate(senderEmail, senderPassword);

                    // E-posta mesajını oluşturun
                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress("Marry US E-Fatura",senderEmail));
                    emailMessage.To.Add(new MailboxAddress("",recipientEmail));
                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart("html") { Text = body };
                    var builder = new BodyBuilder
                    {
                        HtmlBody = body
                    };

                    // PDF dosyasını e-posta ekine ekle
                    builder.Attachments.Add("e-fatura.pdf");

                    emailMessage.Body = builder.ToMessageBody();


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
