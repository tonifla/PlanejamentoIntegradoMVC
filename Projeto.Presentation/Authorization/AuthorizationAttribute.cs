using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Projeto.Presentation.Authorization;
using Projeto.Entities;

namespace Projeto.Presentation.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizationAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public AuthorizationAttribute(params string[] roles) : base() { Roles = string.Join(",", roles); }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (!httpContext.Request.IsAuthenticated)
            //{
            //    return false;
            //}

            Usuario usuario = (Usuario)httpContext.Session["usuarioLogado"];
            if(usuario != null)
            {
                if (String.IsNullOrEmpty(Roles))
                {
                    return true;
                }
                foreach (var perfil in usuario.Perfis)
                {
                    if (this.Roles.Contains(perfil.PRF_CODIGO.Trim()))
                    {
                        return true;
                    }
                }
                return false;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Usuario usuario = (Usuario)filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario != null)
            {
               filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary {
                  { "action", "http401" },
                  { "controller", "Error" },
                  { "area", "" }
                 }
               );
            } else
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                  { "action", "Index" },
                  { "controller", "Login" },
                  { "area", "" }
                  //{ "returnUrl", HttpContext.Current.Request.Url }
                  }
              );
            }       
        }
    }

}