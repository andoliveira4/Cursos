using RotasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> TodasAsNoticias;

        public HomeController()
        {
            TodasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }



        public ActionResult Index()
        {
            var ultimasNoticias = TodasAsNoticias.Take(3);

            var todasAsCategorias = TodasAsNoticias.Select(x => x.Categoria).Distinct().ToList();

            ViewBag.Categorias = todasAsCategorias;

            return View(ultimasNoticias);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}