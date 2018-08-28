using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoa = new Models.Pessoa();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Index(Models.Pessoa pessoa)
        {
            //if (string.IsNullOrEmpty(pessoa.Nome))
            //    ModelState.AddModelError("Nome", "O Campo Nome é obrigatório");
            //if (pessoa.Senha != pessoa.ConfirmaSenha)
            //    ModelState.AddModelError("", "As senhas não conferem");
            if (ModelState.IsValid)
                return View("Resultado", pessoa);
            else
                return View(pessoa);

        }

        public ActionResult Resultado(Models.Pessoa pessoa)
        {
            return View(pessoa);
        }


        public ActionResult LoginUnico(string login)
        {
            var bancoDeNomesDeExemplo = new Collection<string>
            {
                "Cleyton",
                "Anderson",
                "Renata"
            };
            return Json(bancoDeNomesDeExemplo.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}