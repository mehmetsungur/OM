using System;
using System.Web.Mvc;
using System.Net.Mail;
using OM.WebUI.Models;
using System.Configuration;

namespace OM.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EpostaModel model)
        {
            string server = ConfigurationManager.AppSettings["server"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            bool ssl = ConfigurationManager.AppSettings["ssl"].ToString() == "1" ? true : false;

            string from = ConfigurationManager.AppSettings["from"];
            string password = ConfigurationManager.AppSettings["password"];
            string fromname = ConfigurationManager.AppSettings["fromname"];
            string to = ConfigurationManager.AppSettings["to"];
            string copyto = ConfigurationManager.AppSettings["epostacopy"];

            var client = new SmtpClient();
            client.Host = server;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(from, password);

            var email = new MailMessage();
            email.From = new MailAddress(from, fromname);
            email.To.Add(to);

            if (string.IsNullOrEmpty(copyto) == false)
            {
                string[] mails = copyto.Split(',');

                foreach (var item in mails)
                {
                    email.Bcc.Add(item);
                }
            }

            email.Subject = "TEKLİF MESAJI";
            email.IsBodyHtml = true;
            email.Body = $"firma : {model.firma} \n ad soyad : {model.adSoyad} \n  email : {model.email} \n telefon : {model.telefon} \n mesaj : {model.mesaj}";

            try
            {
                client.Send(email);
                ViewData["result"] = "Onay";
                return View("Index");
            }
            catch (Exception)
            {
                ViewData["result"] = "Hata";
                return View("Index", model);
            }
        }
    }
}