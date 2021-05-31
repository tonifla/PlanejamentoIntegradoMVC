using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.BLL;
using Projeto.Presentation.Models;
using AutoMapper;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;
using Projeto.Presentation.Authorization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Projeto.Presentation.Models
{
    public class PlanejamentoController : Controller
    {
        private readonly PlanejamentoBusiness business;
        private readonly string constClientes;


        public PlanejamentoController()
        {
            business = new PlanejamentoBusiness();
            constClientes = "CLIENTES";
        }

        [Authorization("ADM", "CON")]
        public ActionResult ConsultaPIP()
        {
            List<PlanejamentoConsultaPIPViewModel> lista = new List<PlanejamentoConsultaPIPViewModel>();

            try
            {
                lista = Mapper.Map<List<PlanejamentoConsultaPIPViewModel>>(business.ConsultarPlanejamento());
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        [Authorization("ADM", "CON")]
        public ActionResult ConsultaPainel(string PLA_REGIONAL,
                                           string PLA_PROCESSO,
                                           string TIP_TIPO_PROCESSO,
                                           string estadoDoConjunto,
                                           string PLA_CONJUNTO,
                                           string PLA_STATUS_PROGRAMACAO,
                                           bool localTronco = false,
                                           bool localRamal = false,
                                           bool realizarConsulta = false)
        {
            var PlanejamentoConsulta = new DTO.PlanejamentoConsultaPainelDTOViewModel
            {
                RegionaisList = ObterRegionais(),
                ProcessosList = ObterProcessosPorRegional(PLA_REGIONAL),
                TiposDeProcessosList = ObterTiposDeProcessosPorProcesso(PLA_PROCESSO),
                EstadosDosConjuntosList = ObterEstadosDosConjuntosPorTipoDeProcesso(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO),
                ConjuntosList = ObterConjuntosPorEstadoDoConjunto(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO, estadoDoConjunto),
                StatusDasProgramacoesList = ObterStatusDasProgramacoesPorConjunto(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO),
                PLA_REGIONAL = PLA_REGIONAL,
                PLA_PROCESSO = PLA_PROCESSO,
                TIP_TIPO_PROCESSO = TIP_TIPO_PROCESSO,
                EstadoDoConjunto = estadoDoConjunto,
                PLA_CONJUNTO = PLA_CONJUNTO,
                PLA_STATUS_PROGRAMACAO = PLA_STATUS_PROGRAMACAO,
                LocalTronco = localTronco,
                LocalRamal = localRamal,
                RealizarConsulta = realizarConsulta,
                ConsultaPlanejamentoList = new List<PlanejamentoConsultaPainelViewModel>()
            };

            ViewBag.PLA_REGIONAL = PLA_REGIONAL;
            ViewBag.PLA_PROCESSO = PLA_PROCESSO;
            ViewBag.TIP_TIPO_PROCESSO = TIP_TIPO_PROCESSO;
            ViewBag.EstadosDoConjunto = estadoDoConjunto;
            ViewBag.PLA_CONJUNTO = PLA_CONJUNTO;
            ViewBag.PLA_STATUS_PROGRAMACAO = PLA_STATUS_PROGRAMACAO;
            ViewBag.LocalTronco = localTronco;
            ViewBag.LocalRamal = localRamal;
            ViewBag.RealizarConsulta = realizarConsulta;

            if (realizarConsulta)
            {
                if ((!string.IsNullOrEmpty(PLA_REGIONAL) && !string.IsNullOrEmpty(PLA_PROCESSO) && PLA_PROCESSO == constClientes) ||
                    (!string.IsNullOrEmpty(PLA_REGIONAL) && !string.IsNullOrEmpty(PLA_PROCESSO) && !string.IsNullOrEmpty(TIP_TIPO_PROCESSO)))
                {
                    var lista = Mapper.Map<List<PlanejamentoConsultaPainelViewModel>>(business.ConsultarProducao(PLA_REGIONAL,
                                                                                                                 PLA_PROCESSO,
                                                                                                                 TIP_TIPO_PROCESSO,
                                                                                                                 estadoDoConjunto,
                                                                                                                 PLA_CONJUNTO,
                                                                                                                 PLA_STATUS_PROGRAMACAO,
                                                                                                                 localTronco,
                                                                                                                 localRamal));

                    foreach (var item in lista)
                    {
                        var planejamento = new PlanejamentoConsultaPainelViewModel()
                        {
                            TMP_TIPO_PROCESSO = item.TMP_TIPO_PROCESSO,
                            PLA_RANKING_DEC_ATUAL_REGION = item.PLA_RANKING_DEC_ATUAL_REGION,
                            PLA_RANKING_FEC_ATUAL_REGION = item.PLA_RANKING_FEC_ATUAL_REGION,
                            PLA_RANKING_CLIENTE = item.PLA_RANKING_CLIENTE,
                            PLA_PROJETO = item.PLA_PROJETO,
                            PLA_CONJUNTO = item.PLA_CONJUNTO,
                            PLA_ALIMENTADOR = item.PLA_ALIMENTADOR,
                            PLA_IDENTIFICADOR = item.PLA_IDENTIFICADOR,
                            PLA_DISPOSITIVO = item.PLA_DISPOSITIVO,
                            PLA_ACAO = item.PLA_ACAO,
                            PLA_UNIDADE = item.PLA_UNIDADE,
                            PLA_QUANTIDADE_EXECUTADA = item.PLA_QUANTIDADE_PENDENTE,
                            PLA_QTD_SERVICOS_DISPOSITIVO = item.PLA_QTD_SERVICOS_DISPOSITIVO,
                            PLA_QUANTIDADE_PENDENTE = item.PLA_DISPOSITIVO_PENDENTE_PRO,
                            PLA_GAP_CONH_DEZ_ANEEL = item.PLA_GAP_CONH_DEZ_ANEEL,
                            PLA_GAP_CONI_DEZ_ANEEL = item.PLA_GAP_CONI_DEZ_ANEEL,
                            PLA_VALOR_TOTAL = item.PLA_VALOR_TOTAL
                        };
                        PlanejamentoConsulta.ConsultaPlanejamentoList.Add(planejamento);
                    }

                    ViewBag.LoadGraph = true;
                }
                else
                {
                    TempData["Mensagem"] = @"Campos obrigatórios para realizar a consulta:<br />
                                              - Regional<br />
                                              - Processo<br />
                                              - Indicador (se Processo for diferente de 'CLIENTES')";
                }
            }

            return View(PlanejamentoConsulta);
        }

        [Authorization("ADM", "CON")]
        public ActionResult ConsultaDadosProgramacao(string PLA_DISPOSITIVO,
                                                     string PLA_PROJETO,
                                                     bool consultarProgramacao = false)
        {
            var ProgramacaoConsulta = new DTO.PlanejamentoConsultaPainelDTOViewModel
            {
                PLA_DISPOSITIVO = PLA_DISPOSITIVO,
                ProjetosList = ObterProjetosPorDispositivo(PLA_DISPOSITIVO),
                PLA_PROCESSO = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 1),
                OTCorrecao = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 2),
                PLA_CONJUNTO = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 3),
                PLA_ALIMENTADOR = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 4),
                PLA_TOTAL_CLIENTES = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 5),
                PLA_STATUS_PROGRAMACAO = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 6),
                PLA_QUANTIDADE_PLANO_ATUAL = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 7),
                PLA_QUANTIDADE_PENDENTE = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 8),
                PLA_ACAO = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 9),
                PLA_UNIDADE = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 10),
                PLA_IDENTIFICADOR = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 11),
                PLA_GAP_CONH_DEZ_ANEEL = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 12),
                PLA_GAP_CONI_DEZ_ANEEL = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 13),
                PLA_REGIONAL = ObterCampoPorDispositivoProjeto(PLA_DISPOSITIVO, PLA_PROJETO, 14),
                ConsultarProgramacao = consultarProgramacao,
                ConsultaPlanejamentoList = new List<PlanejamentoConsultaPainelViewModel>(),
                ConsultaProgramacaoList = new List<ProgramacaoConsultaViewModel>()
            };

            ViewBag.PLA_DISPOSITIVO = PLA_DISPOSITIVO;
            ViewBag.PLA_PROJETO = PLA_PROJETO;
            ViewBag.ConsultarProgramacao = consultarProgramacao;

            if (consultarProgramacao)
            {
                if (!string.IsNullOrEmpty(PLA_DISPOSITIVO) && !string.IsNullOrEmpty(PLA_PROJETO) && !string.IsNullOrEmpty(ProgramacaoConsulta.PLA_IDENTIFICADOR))
                {
                    var businessProgramacao = new ProgramacaoBusiness();

                    var lista = Mapper.Map<List<ProgramacaoConsultaViewModel>>(businessProgramacao.ConsultarProgramacoesByIdPlanejamento(ProgramacaoConsulta.PLA_IDENTIFICADOR));

                    foreach (var item in lista)
                    {
                        var programacao = new ProgramacaoConsultaViewModel()
                        {
                            PRO_IDENTIFICADOR = item.PRO_IDENTIFICADOR,
                            PRO_PLA_IDENTIFICADOR = item.PRO_PLA_IDENTIFICADOR,
                            PRO_STATUS = item.PRO_STATUS,
                            PRO_QUANTIDADE_A_PROGRAMAR = item.PRO_QUANTIDADE_A_PROGRAMAR,
                            PRO_DATA_PROGRAMACAO = item.PRO_DATA_PROGRAMACAO,
                            PRO_HORA_INICIO_PROGRAMACAO = item.PRO_HORA_INICIO_PROGRAMACAO,
                            PRO_HORA_TERMINO_PROGRAMACAO = item.PRO_HORA_TERMINO_PROGRAMACAO
                        };
                        ProgramacaoConsulta.ConsultaProgramacaoList.Add(programacao);
                    };
                }
                else
                {
                    TempData["Mensagem"] = @"Campos obrigatórios para programar:<br />
                                              - Dispositivo<br />
                                              - Projeto";
                }
            }

            return View(ProgramacaoConsulta);
        }

        [Authorization("ADM", "CON")]
        public ActionResult Exportar()
        {
            try
            {
                //https://www.youtube.com/watch?v=tPvgc-a1ek8

                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                //PlanejamentoConsultaPainelViewModel pm = new PlanejamentoConsultaPainelViewModel();
                //var lista = Mapper.Map<List<PlanejamentoConsultaPainelViewModel>>(business.ConsultarPlanejamento());
                worksheet.Cells[1, 1] = "Regional";
                worksheet.Cells[1, 2] = "Dispositivo";
                worksheet.Cells[1, 3] = "Projeto";
                worksheet.Cells[1, 4] = "Data";
                worksheet.Cells[1, 5] = "Valor total";
                int row = 2;
                foreach (Planejamento p in business.ConsultarPlanejamento())
                {
                    worksheet.Cells[row, 1] = p.PLA_REGIONAL;
                    worksheet.Cells[row, 2] = p.PLA_DISPOSITIVO;
                    worksheet.Cells[row, 3] = p.PLA_PROJETO;
                    worksheet.Cells[row, 4] = p.PLA_DATA_DE_EXECUCAO;
                    worksheet.Cells[row, 5] = p.PLA_VALOR_TOTAL;
                    row++;
                }

                //Largura das colunas
                worksheet.get_Range("A1", "E1").EntireColumn.AutoFit();

                //formatar títulos
                var range_heading = worksheet.get_Range("A1", "E1");
                range_heading.Font.Bold = true;
                range_heading.Font.Color = System.Drawing.Color.Red;
                range_heading.Font.Size = 13;

                //formatar data
                var range_date = worksheet.get_Range("E2", "E10");
                range_date.NumberFormat = "dd/mm/yyyy";
                range_date.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //formatar valor (R$)
                var range_currency = worksheet.get_Range("E2", "E10");
                range_currency.NumberFormat = "R$ #,###,###.00";
                range_currency.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                workbook.SaveAs("D:\\teste.xls");
                workbook.Close();
                Marshal.ReleaseComObject(workbook);

                application.Quit();
                Marshal.FinalReleaseComObject(application);

                TempData["Mensagem"] = @" Dados exportados com sucesso. ";
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = ex.Message;
            }

            return View("Success");
        }

        #region ACTIONS PARA POPULAR COMBOBOX AJAX
        //public JsonResult Regionais()
        //{
        //    return Json(new { data = ObterRegionais() }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult ProcessosPorRegionais(string PLA_REGIONAL)
        {
            return Json(ObterProcessosPorRegional(PLA_REGIONAL), JsonRequestBehavior.AllowGet);
        }

        public JsonResult TiposDeProcessosPorProcesso(string PLA_PROCESSO)
        {
            return Json(ObterTiposDeProcessosPorProcesso(PLA_PROCESSO), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EstadosDosConjuntosPorTipoDeProcesso(string PLA_REGIONAL, string PLA_PROCESSO, string TIP_TIPO_PROCESSO)
        {
            return Json(ObterEstadosDosConjuntosPorTipoDeProcesso(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConjuntosPorEstadoDoConjunto(string PLA_REGIONAL, string PLA_PROCESSO, string TIP_TIPO_PROCESSO, string estadoDoConjunto)
        {
            return Json(ObterConjuntosPorEstadoDoConjunto(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO, estadoDoConjunto), JsonRequestBehavior.AllowGet);
        }

        public JsonResult StatusDasProgramacoesPorConjunto(string PLA_REGIONAL, string PLA_PROCESSO, string TIP_TIPO_PROCESSO)
        {
            return Json(ObterStatusDasProgramacoesPorConjunto(PLA_REGIONAL, PLA_PROCESSO, TIP_TIPO_PROCESSO), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PRIVATE_METHODS_LISTAS
        private List<SelectListItem> ObterRegionais()
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            foreach (var regional in business.ConsultarRegional()) lista.Add(new SelectListItem()
            { Text = regional.PLA_REGIONAL, Value = regional.PLA_REGIONAL });

            return lista;
        }

        private List<SelectListItem> ObterProcessosPorRegional(string regional)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if (!string.IsNullOrEmpty(regional))
            {
                foreach (var processo in business.ConsultarProcesso(regional)) lista.Add(new SelectListItem()
                { Text = processo.PLA_PROCESSO, Value = processo.PLA_PROCESSO });
            }
            return lista;
        }

        private List<SelectListItem> ObterTiposDeProcessosPorProcesso(string processo)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if (!string.IsNullOrEmpty(processo))
            {
                foreach (var TipoDeProcesso in business.ConsultarTipoProcesso(processo)) lista.Add(new SelectListItem()
                { Text = TipoDeProcesso.TMP_TIPO_PROCESSO, Value = TipoDeProcesso.TMP_TIPO_PROCESSO });
            }
            return lista;
        }

        private List<SelectListItem> ObterEstadosDosConjuntosPorTipoDeProcesso(string regional,
                                                                               string processo,
                                                                               string tipoDeProcesso)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if (!string.IsNullOrEmpty(regional) || !string.IsNullOrEmpty(processo) || !string.IsNullOrEmpty(tipoDeProcesso))
            {
                foreach (var EstadoDoConjunto in business.ConsultarEstadoConjunto(regional,
                                                                                              processo,
                                                                                              tipoDeProcesso)) lista.Add(new SelectListItem()
                                                                                              { Text = EstadoDoConjunto.TMP_ESTADO_CONJUNTO_DEC_FEC, Value = EstadoDoConjunto.TMP_ESTADO_CONJUNTO_DEC_FEC });
            }
            return lista;
        }

        private List<SelectListItem> ObterConjuntosPorEstadoDoConjunto(string regional,
                                                                       string processo,
                                                                       string tipoDeProcesso,
                                                                       string estadoDoConjunto)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if (!string.IsNullOrEmpty(regional) || !string.IsNullOrEmpty(processo) || !string.IsNullOrEmpty(tipoDeProcesso) || !string.IsNullOrEmpty(estadoDoConjunto))
            {
                foreach (var Conjunto in business.ConsultarConjunto(regional,
                                                                                processo,
                                                                                tipoDeProcesso,
                                                                                estadoDoConjunto)) lista.Add(new SelectListItem()
                                                                                { Text = Conjunto.PLA_CONJUNTO, Value = Conjunto.PLA_CONJUNTO });
            }
            return lista;
        }

        private List<SelectListItem> ObterStatusDasProgramacoesPorConjunto(string regional,
                                                                           string processo,
                                                                           string tipoDeProcesso)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if ((!string.IsNullOrEmpty(regional) && !string.IsNullOrEmpty(processo) && processo == constClientes) ||
                (!string.IsNullOrEmpty(regional) && !string.IsNullOrEmpty(processo) && !string.IsNullOrEmpty(tipoDeProcesso)))
            {
                foreach (var StatusDaProgramacao in business.ConsultarStatusProgramacao(regional,
                                                                                                    processo,
                                                                                                    tipoDeProcesso)) lista.Add(new SelectListItem()
                                                                                                    { Text = StatusDaProgramacao.PLA_STATUS_PROGRAMACAO, Value = StatusDaProgramacao.PLA_STATUS_PROGRAMACAO });
            }
            return lista;
        }

        private List<SelectListItem> ObterProjetosPorDispositivo(string dispositivo)
        {
            var lista = new List<SelectListItem>
            { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

            if (!string.IsNullOrEmpty(dispositivo))
            {
                foreach (var projeto in business.ConsultarProjeto(dispositivo)) lista.Add(new SelectListItem()
                { Text = projeto.PLA_PROJETO, Value = projeto.PLA_PROJETO });
            }
            return lista;
        }

        private string ObterCampoPorDispositivoProjeto(string dispositivo, string projeto, int valor)
        {
            string informacao = null;

            if (!string.IsNullOrEmpty(dispositivo) && !string.IsNullOrEmpty(projeto))
            {
                informacao = business.ConsultarCampoPorDispositivoProjeto(dispositivo, projeto, valor);
            }

            return (informacao == null) ? string.Empty : informacao.ToString();
        }
        #endregion

        #region GRÁFICOS
        public async Task<JsonResult> ObterDadosDeDesvioPorRegional(string regional, string tipoGrafico)
        {
            try
            {
                var listaPlanejameneto = await business.ObterDadosDeDesvioPorRegional(regional, tipoGrafico);
                var planejamentos = new List<Planejamento>();

                foreach (var item in listaPlanejameneto)
                {
                    Planejamento model = new Planejamento()
                    {
                        PLA_CONJUNTO = item.PLA_CONJUNTO,
                        PLA_DESVIO_DEC = item.PLA_DESVIO_DEC,
                        PLA_DESVIO_FEC = item.PLA_DESVIO_FEC,
                        PLA_LOCAL = item.PLA_LOCAL
                    };

                    planejamentos.Add(model);
                }

                return Json(planejamentos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<JsonResult> ObterDadosDeQualidadeManutencao(string regional, string limite, string local)
        {
            try
            {
                var planejamentos = new List<Planejamento>();
                var listaPlanejamento = await business.ObterDadosDeQualidadeManutencao(regional, limite, local);

                foreach (var item in listaPlanejamento)
                {
                    Planejamento model = new Planejamento()
                    {
                        PLA_ESTADO_CONJUNTO_DEC_LIMITE = item.PLA_ESTADO_CONJUNTO_DEC_LIMITE,
                        PLA_LOCAL = item.PLA_LOCAL,
                        PLA_QTDE_LOCAL = item.PLA_QTDE_LOCAL
                    };

                    planejamentos.Add(model);
                }

                return Json(planejamentos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<JsonResult> ObterDadosObrasCliente(string regional, string tipo)
        {
            try
            {
                var obrasCliente = await business.ObterDadosObrasCliente(regional, tipo);
                var qtdeDiasVencindos = new JavaScriptSerializer().Serialize(obrasCliente);

                return Json(qtdeDiasVencindos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

    }
}