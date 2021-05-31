using Projeto.BLL;
using Projeto.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioBusiness usuarioBusiness;
        private LoginViewModel loginViewModel = new LoginViewModel();

        public LoginController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }

        public ActionResult Index()
        {
            bool isBrowserSupported;

            isBrowserSupported = false;

            isBrowserSupported = (((Request.Browser.Browser.Equals("Chrome") &&
                                    Request.Browser.MajorVersion >= 45) ||

                                   (Request.Browser.Browser.Equals("Firefox") &&
                                    Request.Browser.MajorVersion >= 38) ||

                                   (Request.Browser.Browser.Equals("Edge") &&
                                    Request.Browser.MajorVersion >= 12) ||

                                   (Request.Browser.Browser.Equals("IE") || Request.Browser.Browser.Equals("InternetExplorer")) &&
                                    Request.Browser.MajorVersion >= 10) ||

                                   (Request.Browser.Browser.Equals("Opera") &&
                                    Request.Browser.MajorVersion >= 30));

            if (!isBrowserSupported)
            {
                string navegador;

                navegador = string.Format($@" <br/><b>Seu Navegador está desatualizado.</b><br/>
                                              Navegador: { Request.Browser.Browser} <br/>
                                              Versão: { Request.Browser.MajorVersion}");

                Response.Write(navegador);

                return View("IndexErroNavegador");
            }
            else
            {
                return View(loginViewModel);
            }
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retornoAutenticacao = usuarioBusiness.AutenticarLogin(loginViewModel.Login.ToUpper(), loginViewModel.Senha.Trim());

                    if (retornoAutenticacao.Success)
                    {
                        FormsAuthentication.SetAuthCookie(retornoAutenticacao.Usuario.USU_LOGIN, false);
                        Session["usuarioLogado"] = retornoAutenticacao.Usuario;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Mensagem"] = retornoAutenticacao.Message;
                        return View("Index", loginViewModel);
                    }
                }

                TempData["Mensagem"] = "Campos não preenchidos";
                return View("Index", loginViewModel);
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Não foi possível realizar o login";
                return View("Index", loginViewModel);
            }

        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;

            return RedirectToAction("Index");
        }
    }
}