using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login não informado.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha não informada.")]
        public string Senha { get; set; }
    }
}