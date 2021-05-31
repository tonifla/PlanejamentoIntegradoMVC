using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class PlanejamentoBusiness
    {
        private PlanejamentoRepository repository;

        public PlanejamentoBusiness()
        {
            repository = new PlanejamentoRepository();
        }

        public List<Planejamento> ConsultarRegional()
        {
            return repository.SelectByRegional();
        }

        public List<Planejamento> ConsultarProcesso(string regional)
        {
            return repository.SelectByProcesso(regional);
        }

        public List<Planejamento> ConsultarTipoProcesso(string processo)
        {
            return repository.SelectByTipoProcesso(processo);
        }

        public List<Planejamento> ConsultarEstadoConjunto(string regional,
                                                          string processo,
                                                          string tipoDeProcesso)
        {
            return repository.SelectByEstadoConjunto(regional,
                                                     processo,
                                                     tipoDeProcesso);
        }

        public List<Planejamento> ConsultarConjunto(string regional,
                                                    string processo,
                                                    string tipoDeProcesso,
                                                    string estado)
        {
            return repository.SelectByConjunto(regional,
                                               processo,
                                               tipoDeProcesso,
                                               estado);
        }

        public List<Planejamento> ConsultarStatusProgramacao(string regional,
                                                             string processo,
                                                             string tipoDeProcesso)
        {
            return repository.SelectByStatusProgramacao(regional,
                                                        processo,
                                                        tipoDeProcesso);
        }

        public List<Planejamento> ConsultarLocal(string regional)
        {
            return repository.SelectByLocal(regional);
        }

        public List<Planejamento> ConsultarProducao(string regional,
                                                    string processo,
                                                    string tipoDeProcesso,
                                                    string estadoDoConjunto,
                                                    string conjunto,
                                                    string statusDaProgramacao,
                                                    bool localTronco,
                                                    bool localRamal)
        {
            return repository.SelectByProducao(regional,
                                               processo,
                                               tipoDeProcesso,
                                               estadoDoConjunto,
                                               conjunto,
                                               statusDaProgramacao,
                                               localTronco,
                                               localRamal);
        }

        public List<Planejamento> ConsultarPlanejamento()
        {
            return repository.SelectAll();
        }

        public List<Planejamento> ConsultarPlanejamentoPorId(string id)
        {
            return repository.SelectById(id);
        }

        public List<Planejamento> ConsultarDadosProjeto(string dispositivo, string projeto)
        {
            return repository.SelectByDadosProjeto(dispositivo, projeto);
        }

        public List<Planejamento> ConsultarProjeto(string dispositivo)
        {
            return repository.SelectByProjeto(dispositivo);
        }

        public string ConsultarCampoPorDispositivoProjeto(string dispositivo, string projeto, int valor)
        {
            return repository.SelectByFieldPorDispositivoProjeto(dispositivo, projeto, valor);
        }


        #region GRÁFICOS
        public async Task<List<Planejamento>> ObterDadosDeDesvioPorRegional(string regional, string tipoGrafico)
        {
            return await repository.ObterDadosDeDesvioPorRegional(regional, tipoGrafico);
        }

        public async Task<List<Planejamento>> ObterDadosDeQualidadeManutencao(string regional, string limite, string local)
        {
            return await repository.ObterDadosDeQualidadeManutencao(regional, limite, local);
        }

        public async Task<List<int>> ObterDadosObrasCliente(string regional, string tipo)
        {
            return await repository.ObterDadosObrasCliente(regional, tipo);
        }
        #endregion
    }
}
