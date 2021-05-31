using Projeto.Presentation.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
    public class HomeController : Controller
    {
        [Authorization("ADM", "CON", "CAD")]
        public ActionResult Index()
        {
            return View();
        }
    }
}