using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Controllers
{
    public class SiteController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.Home = "active";
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Sobre = "active";
            return View();
        }

        public ActionResult Planos()
        {
            ViewBag.Planos = "active";
            return View();
        }

        public ActionResult Servicos()
        {
            ViewBag.Servicos = "active";
            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Contato = "active";
            return View();
        }


        [HttpPost]
        public ActionResult Contato(Contato contatoForm)
        {
            Contato formTratado = ContatoUtil.ToFirstUpper(contatoForm);

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("onsaba@gmail.com");
                mail.From = new MailAddress(formTratado.email, formTratado.fName);
                mail.Subject = "Email do site ON SABA";
                string Body = "Nome: " + formTratado.fName + " " + formTratado.lName + "<br />" + "Email: " + formTratado.email + "<br />" + "Telefone: " + formTratado.phone + "<br />" + "Mensagem: " + formTratado.message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("onsaba@gmail.com", "onsaba2014");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);

                ViewBag.sucesso = "Email enviado com sucesso. Em breve retornaremos o contato, obrigado.";
            }
            else
            {
                ViewBag.erro = "Ops.. Estamos com problemas, tenta novamente em breve.";
                return View("Contato");
            }

            return View("Contato");
        }
    }
}