using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class EquipeBusiness
    {
        private EquipeRepository repository;

        public EquipeBusiness()
        {
            repository = new EquipeRepository();
        }

        public void CadastrarEquipe(Equipe equipe)
        {
            repository.Insert(equipe);
        }

        public void AtualizarEquipe(Equipe equipe)
        {
            repository.Update(equipe);
        }

        public Equipe ConsultarEquipePorId(int id)
        {
            return repository.SelectById(id);
        }

        public void RemoverEquipe(int idEquipe)
        {
            repository.Delete(idEquipe);
        }

        public void RemoverTodasEquipes(int idProgramacao)
        {
            repository.DeleteAll(idProgramacao);
        }

        public List<Equipe> ConsultarEquipesPorIdProgramacao(int id)
        {
            return repository.SelectEquipesByIdProgramacao(id);
        }

        public List<Equipe> ConsultarTiposDeEquipesPorRecurso(string regional)
        {
            return repository.SelectByTiposDeEquipesPorRecurso(regional);
        }

        public List<Equipe> ConsultarDescricoesPorRecurso(string regional,
                                                          string tipoDeEquipe)
        {
            return repository.SelectByDescricoesPorRecurso(regional,
                                                           tipoDeEquipe);
        }

        public int ConsultarQuantidadePorRecurso(string regional,
                                                 string tipoDeEquipe,
                                                 string descricao)
        {
            return repository.SelectByQuantidadePorRecurso(regional,
                                                           tipoDeEquipe,
                                                           descricao);
        }

        public List<Equipe> ConsultarParceiraPorRecurso(string regional,
                                                        string tipoDeEquipe,
                                                        string descricao,
                                                        int quantidade)
        {
            return repository.SelectByParceiraPorRecurso(regional,
                                                         tipoDeEquipe,
                                                         descricao,
                                                         quantidade);
        }
    }
}
