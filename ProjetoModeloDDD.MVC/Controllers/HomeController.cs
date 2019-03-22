using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Projeto criado com as tecnologias ASP.Net MVC5 e EntityFramework 6";
            ViewBag.Message = "Project created with ASP.Net MVC5, Bootstrap 4.3.1 and EntityFramework 6 technologies.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Me encontre nas redes sociais!";

            return View();
        }
    }
}