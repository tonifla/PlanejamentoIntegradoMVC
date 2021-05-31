using Projeto.Presentation.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
   [Authorization]
    public class ErrorController : Controller
    {

        // GET: Error
        //public ActionResult http500()
        //{
        //    return View("Error");
        //}

        //public ActionResult http404()
        //{
        //    return View("NoPageFound");
        //}

        public ActionResult http401()
        {
            return View("Unauthorized");
        }


    }
}