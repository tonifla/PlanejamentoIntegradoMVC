using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Usuario
    {
        public long USU_IDENTIFICADOR { get; set; }
        public string USU_LOGIN { get; set; }
        public string USU_NOME { get; set; }
        public string USU_EMAIL { get; set; }
        public string USU_SENHA { get; set; }
        public bool USU_ATIVO { get; set; }

        public List<Perfil> Perfis { get; set; }

        public Usuario()
        {
            Perfis = new List<Perfil>();
        }
        public Usuario(long id, string login, string nome, string email, string senha, bool ativo)
        {
            USU_IDENTIFICADOR = id;
            USU_LOGIN = login;
            USU_NOME = nome;
            USU_EMAIL = email;
            USU_SENHA = senha;
            USU_ATIVO = ativo;
        }
    }
}
