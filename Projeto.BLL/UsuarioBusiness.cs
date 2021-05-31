using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;

namespace Projeto.BLL
{
    public class UsuarioBusiness
    {
        private UsuarioRepository repository;

        public UsuarioBusiness()
        {
            repository = new UsuarioRepository();
        }

        public List<Usuario> ConsultarTodos()
        {
            return repository.SelectAll();
        }

        public Usuario ConsultarPorId(long id)
        {
            return repository.SelectById(id);
        }

        public Usuario ConsultarPorLogin(string login)
        {
            return repository.SelectByLogin(login);
        }

        public DefaultResponse AutenticarLogin(string login, string senha)
        {
            Usuario usuario = repository.SelectByLoginSenha(login, senha);

            if (usuario == null)
                return new DefaultResponse() { Success = false, Message = "Login ou senha incorreta." };

            if (!usuario.USU_ATIVO)
                return new DefaultResponse() { Success = false, Message = "Usuário Inativo" };

            return new DefaultResponse() { Success = true, Usuario = usuario };
        }
    }
}
