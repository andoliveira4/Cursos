using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostGetModel.Controllers
{
    public class Home2Controller : Controller
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
        public ActionResult Lista(string PessoaId, string Nome, string Twitter)
        {
            ViewData["PessoaId"] = PessoaId;
            ViewData["Nome"] = Nome;
            ViewData["Twitter"] = Twitter;
            return View();
        }
    }
}