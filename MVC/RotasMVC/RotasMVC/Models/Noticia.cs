using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotasMVC.Models
{
    public class Noticia
    {
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string  Categoria { get; set; }
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString ="{0:dd/MM/yyyy")]
        public DateTime Data { get; set; }

        public IEnumerable<Noticia> TodasAsNoticias()
        {
            var retorno = new System.Collections.ObjectModel.Collection<Noticia>
            {
                new Noticia
                {
                    NoticiaId = 1,
                    Categoria = "Esportes",
                    Titulo = "Esportes",
                    Conteudo = "Numa tarde de chuva Felipe Massa ganha F1 no Brasil...",
                    Data = new DateTime(2012,7,5)
                },
                new Noticia
                {
                    NoticiaId = 2,
                    Categoria = "Politica",
                    Titulo = "Presidente assina convênios",
                    Conteudo = "Durante reunião o presidente Ismael freitas assinou os convênios...",
                    Data = new DateTime(2012,7,5)
                },
                new Noticia
                {
                    NoticiaId = 3,
                    Categoria = "Saude",
                    Titulo = "estou doente",
                    Conteudo = "é mesmo que coisa",
                    Data = new DateTime(2012,7,5)
                },
                new Noticia
                {
                    NoticiaId = 4,
                    Categoria = "Amor",
                    Titulo = "Amo meu marido",
                    Conteudo = "mas quero o divorcio, ele ronca muito",
                    Data = new DateTime(2012,7,5)
                }
            };
            return retorno;
        }
    }
}