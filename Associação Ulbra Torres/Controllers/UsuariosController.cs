using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Repositorio;
using Associação_Ulbra_Torres.Models.Utilitarios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Controllers
{

    public class UsuariosController : Controller
    {
        public static Usuarios userReturn;

        public ActionResult LogIn()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Usuarios user, FormCollection form)
        {
            if (user.email != string.Empty && user.senha != string.Empty)
            {
                userReturn = UsuariosRepositorio.GetUser(user);

                var rememberValue = form["lembrar"];

                if (userReturn != null)
                {
                    if (rememberValue == "true")
                    {
                        //autenticacao do usuario, cokie indestrutivel mesmo fechando navegador
                        System.Web.Security.FormsAuthentication.SetAuthCookie(userReturn.idUsuario.ToString(), true);
                    }
                    else
                    {
                        // autenticacao do usuario, destroi cokie ao fechar navegador
                        System.Web.Security.FormsAuthentication.SetAuthCookie(userReturn.idUsuario.ToString(), false);
                    }

                    SetCookie("userLogado", userReturn.nome);
                     
                    return Redirect("/Home/Index");
                }

            }

            ViewBag.ErrorUserEkey = "Email ou Senha incorretos. Verifique-os e tente novamente.";
            return View();
        }

        public void SetCookie(string key, string value)
        {
            var encValue = Server.UrlTokenEncode(UTF8Encoding.UTF8.GetBytes(value));
            var c = new HttpCookie(key, encValue) { Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Add(c);
        }

        public ActionResult LogOff()
        {
            //rotina para remover autenticacao do usuario
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("/Usuarios/LogIn");
        }

        public ActionResult NovoUsuario()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.Name;
                Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);
                @ViewBag.nome = UsuarioLogado.nome;
                @ViewBag.email = UsuarioLogado.email;

                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult NovoUsuario(Usuarios pUser)
        {
            if (UsuariosRepositorio.VerificaEmail(pUser.email))
            {
                Usuarios pUserTratado = UsuariosUtil.ToLowerUsuario(pUser);
                Usuarios pUserMail = UsuariosUtil.ToFirstUpper(pUserTratado);
                int id = UsuariosRepositorio.Create(pUserTratado);


                if (ModelState.IsValid)
                {   
                    MailMessage mail = new MailMessage();
                    mail.To.Add(pUser.email);
                    mail.From = new MailAddress("onsaba@gmail.com", "ON SABA");
                    mail.Subject = "Confirmação cadastro ON SABA";
                    string Body = "<img src=\"http://saofrancisco.azurewebsites.net/Content/Imagens/onsaba.png\" height=\"65\"> <br /> <h3>Obrigado por inscrever-se no ON SABA " + pUserMail.nome + "</h3> <br /> <p>Ative sua conta no link abaixo e aproveite!</p> <br /> <a href=http://saofrancisco.azurewebsites.net/Usuarios/ConfirmacaoEmail?pIdUser=" + id + "> << Ative aqui >> </a>";
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
                    ViewBag.sucesso = "Para finalizar o cadastro, confirme a conta no email informado.";

                    var userId = User.Identity.Name;
                    Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);
                    return View("Conta", UsuarioLogado);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.aviso = "Email já existente, tente outro.";
                return View("NovoUsuario");
            }
        }

        public ActionResult ConfirmacaoEmail(string pIdUser)
        {
            try
            {
                UsuariosRepositorio.UpdateVerificacao(pIdUser);
                ViewBag.sucesso = "Email verificado com sucesso, faça login e aproveite!";
            }
            catch (MySqlException ex)
            {
                ViewBag.sucesso = "Falha ao validar email, tenta novamente mais tarde.";
                throw ex;
            }
            
            return View("LogIn");
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(Usuarios pUser)
        {
            if (UsuariosRepositorio.VerificaEmail(pUser.email)==false)
            {
                Usuarios User = UsuariosRepositorio.GetUserEmail(pUser.email);

                MailMessage mail = new MailMessage();
                mail.To.Add(pUser.email);
                mail.From = new MailAddress("onsaba@gmail.com", "ON SABA");
                mail.Subject = "Alterar senha cadastro ON SABA";
                string Body = "<img src=\"http://saofrancisco.azurewebsites.net/Content/Imagens/onsaba.png\" height=\"65\"> <br /> <h3>Altere sua senha agora no ON SABA " + User.nome + "</h3> <br /> <a href=http://saofrancisco.azurewebsites.net/Usuarios/AlterarSenhaCadastro?pEmail=" + User.email + "> << Alterar Senha >> </a>";
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

                ViewBag.aviso = "OK! Uma solicitação para alterar a senha foi enviado ao email informado.";
                return View("AlterarSenha");
            }
            else
            {
                ViewBag.aviso = "OPS! Não é possível fazer alteração da senha do email informado. Verifique o email.";
                return View("AlterarSenha");
            }
            
        }

        public ActionResult AlterarSenhaCadastro(string pEmail)
        {
            Usuarios pUser = UsuariosRepositorio.GetUserEmail(pEmail);

            return View(pUser);
        }

        [HttpPost]
        public ActionResult AlterarSenhaCadastro(Usuarios pUser)
        {
            UsuariosRepositorio.AlteraSenha(pUser);

            ViewBag.sucesso = "Senha alterada com sucesso.";
            return View("LogIn");
        }

        public ActionResult AlterarSenhaPainel()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.Name;
                Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);
                UsuarioLogado.senha = "";

                @ViewBag.nome = UsuarioLogado.nome;
                @ViewBag.email = UsuarioLogado.email;

                return View(UsuarioLogado);
            }

            return RedirectToAction("LogIn");
        }

        [HttpPost]
        public ActionResult AlterarSenhaPainel(Usuarios pUser)
        {
            UsuariosRepositorio.AlteraSenha(pUser);

            ViewBag.sucesso = "Senha alterada com sucesso.";
            Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(pUser.idUsuario.ToString());

            return View("Conta", UsuarioLogado);
        }

        public ActionResult Conta()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.Name;
                Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);

                return View(UsuarioLogado);
            }

            return RedirectToAction("LogIn");
        }

        public ActionResult EditarUsuario()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.Name;
                Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);

                return View(UsuarioLogado);
            }

            return RedirectToAction("LogIn");
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuarios pUser)
        {
            UsuariosRepositorio.EditarUsuario(pUser);

            ViewBag.sucesso = "Usuário editado com sucesso, suas informações serão atualizadas no próximo Login.";
            Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(pUser.idUsuario.ToString());

            return View("Conta", UsuarioLogado);
        }

        public ActionResult ExcluirConta()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.Name;
                Usuarios UsuarioLogado = UsuariosRepositorio.GetUserId(userId);

                return View(UsuarioLogado);
            }

            return RedirectToAction("LogIn");
        }

        [HttpPost]
        public ActionResult ExcluirConta(Usuarios pUser)
        {
            UsuariosRepositorio.ExcluirConta(pUser);
            LogOff();
            return View("LogIn");
        }
    }
}