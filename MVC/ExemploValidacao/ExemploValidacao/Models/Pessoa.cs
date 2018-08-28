using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage ="Nome deve ser preenchido")]        
        public string Nome { get; set; }
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A observação deve ter entre 5 e 50 caracteres")]
        public string Observacao { get; set; }
        [Range(18,50,ErrorMessage = "A mensagem da pessoa deve ser entre 18 e 50 anos")]
        public int Idade { get; set; }

        [RegularExpression(@"/^[a - z0 - 9.] +@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i",ErrorMessage ="Email informado não é valido")]
        public string Email { get; set; }

        //[RegularExpression(@"[a-z][A-Z]{5,15}", ErrorMessage = "Login possuir somente letras e deve ter de 5 a 15 caracteres")]
        [Required(ErrorMessage = "O Login deve ser preenchido")]
        [Remote("LoginUnico","Pessoa", ErrorMessage="Este nome de login já existe")]        
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha",ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }        
    }
}