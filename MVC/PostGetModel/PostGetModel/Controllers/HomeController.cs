using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostGetModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pessoa = new Models.Pessoa
            {
                PessoaId = "1",
                Nome = "Cleyton Ferrari",
                Twitter = "@cleytonferrari"
            };
            //ViewBag.PessoaId = pessoa.PessoaId;
            //ViewBag.NomeDaPessoa = pessoa.Nome;
            //ViewData["Twitter"] = pessoa.Twitter;
            return View(pessoa);
        }

        [HttpPost]
        //public ActionResult Lista(string PessoaId, string Nome, string Twitter)
        //public ActionResult Lista(FormCollection form)
        public ActionResult Lista(Models.Pessoa pessoa)
        {
            //ViewData["PessoaId"] = PessoaId;
            //ViewData["Nome"] = Nome;
            //ViewData["Twitter"] = Twitter;
            //ViewData["PessoaId"] = form["PessoaId"];
            //ViewData["Nome"] = form["Nome"];
            //ViewData["Twitter"] = form["Twitter"];
            //ViewData["PessoaId"] = pessoa.PessoaId;
            //ViewData["Nome"] = pessoa.Nome;
            //ViewData["Twitter"] = pessoa.Twitter;
            //return View();
            return View(pessoa);
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