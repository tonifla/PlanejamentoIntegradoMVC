using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class ImportacaoArquivo
    {
        [Required(ErrorMessage = "O Arquivo é obrigatório.")]
        public HttpPostedFileBase Arquivo { get; set; }

        internal String RetornarConteudoArquivo(Stream fileStream)
        {
            String conteudoArquivo;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                conteudoArquivo = reader.ReadToEnd();
            }
            return conteudoArquivo;
        }
    }
}