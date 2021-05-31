using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class ProgramacaoBusiness
    {
        private ProgramacaoRepository repository;

        public ProgramacaoBusiness()
        {
            repository = new ProgramacaoRepository();
        }

        public int CadastrarProgramacao(Programacao programacao)
        {
            return repository.Insert(programacao);
        }

        public void AtualizarProgramacao(Programacao programacao)
        {
            repository.Update(programacao);
        }

        public List<Programacao> ConsultarMotivosProgramacao()
        {
            return repository.SelectMotivosProgramacao();
        }

        public List<Programacao> ConsultarProgramacoesByIdPlanejamento(string id)
        {
            return repository.SelectProgramacoesByIdPlanejamento(id);
        }

        public Programacao ConsultarProgramacaoPorId(int id)
        {
            return repository.SelectProgramacaoById(id);
        }
    }
}
