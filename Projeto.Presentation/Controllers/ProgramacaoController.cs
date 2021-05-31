using Projeto.BLL;
using Projeto.Entities;
using Projeto.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;
using Projeto.Presentation.Authorization;

namespace Projeto.Presentation.Controllers
{
    public class ProgramacaoController : Controller
    {
        private ProgramacaoBusiness business;
        private EquipeBusiness equipeBusiness;

        public ProgramacaoController()
        {
            business = new ProgramacaoBusiness();
            equipeBusiness = new EquipeBusiness();
        }

        [Authorization("ADM", "CON")]
        public ActionResult Cadastro(string PRO_PLA_IDENTIFICADOR,
                                     string PLA_REGIONAL,
                                     string PLA_PROJETO,
                                     string PLA_DISPOSITIVO,
                                     string PRO_DISPOSITIVO,
                                     string PRO_QUANTIDADE_CLIENTE,
                                     string PRO_IMPACTO_CONH,
                                     string PRO_IMPACTO_CONI,
                                     string PLA_UNIDADE)
        {
            ViewBag.PRO_PLA_IDENTIFICADOR = PRO_PLA_IDENTIFICADOR;
            ViewBag.PLA_REGIONAL = PLA_REGIONAL;
            ViewBag.PLA_PROJETO = PLA_PROJETO;
            ViewBag.PLA_DISPOSITIVO = PLA_DISPOSITIVO;
            ViewBag.PRO_DISPOSITIVO = PRO_DISPOSITIVO;
            ViewBag.PRO_QUANTIDADE_CLIENTE = PRO_QUANTIDADE_CLIENTE;
            ViewBag.PRO_IMPACTO_CONH = PRO_IMPACTO_CONH;
            ViewBag.PRO_IMPACTO_CONI = PRO_IMPACTO_CONI;
            ViewBag.PLA_UNIDADE = PLA_UNIDADE;

            if (Session["address"] != null)
            {
                Session["address"] = null;
            }

            return View(new ProgramacaoCadastroViewModel());
        }

        [Authorization("ADM", "CON")]
        [HttpPost]
        public ActionResult Cadastro(ProgramacaoCadastroViewModel model)
        {
            //// camadinha de validação

            //if (model.PRO_IMPEDIMENTO == "1")
            //{
            //    if (string.IsNullOrEmpty(model.PRO_MOTIVO))
            //    {
            //        ModelState.AddModelError("erro_pro_motivo", "essa merad ai");
            //    }

            //    // ...
            //}

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
          


            if (model.PRO_IMPEDIMENTO == "1")
            {
                model.PRO_DATA_PROGRAMACAO = null;
                model.PRO_HORA_INICIO_PROGRAMACAO = null;
                model.PRO_HORA_TERMINO_PROGRAMACAO = null;
                model.PRO_QUANTIDADE_A_PROGRAMAR = null;
                model.PRO_DESLIGAMENTO = "0";
                model.PRO_HORA_INICIO_SGD = null;
                model.PRO_HORA_TERMINO_SGD = null;
                model.PRO_NUMERO_SGD = null;
                model.PRO_RECURSO_BIG_JUMPER = false;
                model.PRO_RECURSO_CHAVE_PROVISORIA = false;
                model.PRO_RECURSO_GERADOR = false;
                model.PRO_RECURSO_INTERLIGACAO_REDE = false;
                model.PRO_RECURSO_LINHA_VIVA = false;
                model.PRO_RECURSO_SEM_RECURSO = true;
            }
            else if (model.PRO_IMPEDIMENTO == "0")
            {
                model.PRO_MOTIVO = "12";
            }

            model.PRO_USU_IDENTIFICADOR = Convert.ToInt32(((Usuario)Session["usuarioLogado"]).USU_IDENTIFICADOR);

            if (Session["address"] == null)
            {
                Session["address"] = new List<EquipeCadastroViewModel>(); ;
            }

            ModelState.Clear();

            var equipes = (IEnumerable<EquipeCadastroViewModel>)Session["address"];

            if ((model.PRO_IMPEDIMENTO == "0") && (equipes.FirstOrDefault() == null))
            {
                ModelState.AddModelError("erro_inserir_equipe", "É necessário ao menos uma equipe para gravar.");
            }

            //TODO: ver com o Victor -validação
            //if (ModelState.IsValid)
            if (
                   //impedimento = SIM
                   (
                        (model.PRO_IMPEDIMENTO == "1") &&
                        (!string.IsNullOrEmpty(model.PRO_MOTIVO)) &&
                        (Convert.ToInt16(model.PRO_MOTIVO) != 12) &&
                        (model.PRO_RECURSO_SEM_RECURSO)
                   ) ||
                   //impedimento = NÃO
                   (
                        //(equipes.Any()) &&
                        (equipes.Count() > 0) &&
                        (model.PRO_IMPEDIMENTO == "0") &&
                        (model.PRO_DATA_PROGRAMACAO >= DateTime.Now.Date) &&
                        (model.PRO_HORA_TERMINO_PROGRAMACAO > model.PRO_HORA_INICIO_PROGRAMACAO) &&
                        (!string.IsNullOrEmpty(model.PRO_QUANTIDADE_A_PROGRAMAR)) &&
                        (!string.IsNullOrEmpty(model.PRO_DESLIGAMENTO)) &&
                        (!string.IsNullOrEmpty(model.PRO_DISPOSITIVO)) &&
                        (model.PRO_QUANTIDADE_CLIENTE >= 0) &&
                        (!string.IsNullOrEmpty(model.PRO_IMPACTO_CONH)) &&
                        (!string.IsNullOrEmpty(model.PRO_IMPACTO_CONI)) &&
                        (
                            (model.PRO_RECURSO_BIG_JUMPER) ||
                            (model.PRO_RECURSO_CHAVE_PROVISORIA) ||
                            (model.PRO_RECURSO_GERADOR) ||
                            (model.PRO_RECURSO_INTERLIGACAO_REDE) ||
                            (model.PRO_RECURSO_LINHA_VIVA) ||
                            (model.PRO_RECURSO_SEM_RECURSO)
                        )
                   )
               )
            {
                try
                {
                    Programacao programacao = Mapper.Map<Programacao>(model);

                    CadastrarEquipes(business.CadastrarProgramacao(programacao));

                    TempData["Mensagem"] = $"Programação para o dispositivo {programacao.PRO_DISPOSITIVO ?? programacao.Planejamento.PLA_DISPOSITIVO}, cadastrado com sucesso.";
                    ModelState.Clear();

                    string url = Url.Action("ConsultaDadosProgramacao", "Planejamento", new { PLA_DISPOSITIVO = model.PLA_DISPOSITIVO, PLA_PROJETO = model.PLA_PROJETO, ConsultarProgramacao = true });
                    //var url = "~/Planejamento/ConsultaDadosProgramacao?PLA_DISPOSITIVO=" + model.PLA_DISPOSITIVO + "&PLA_PROJETO=" + model.PLA_PROJETO + "&ConsultarProgramacao=true";

                    return Redirect(url);
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            else
            {
                TempData["Mensagem"] = @"Campos obrigatórios não foram preenchidos ou preenchidos incorretamente.";
            }

            return View(model);
        }

        private void CadastrarEquipes(int idProgramacao)
        {
            var a = new List<EquipeCadastroViewModel>();

            if (Session["address"] == null)
            {
                Session["address"] = a;
            }

            a = ((IEnumerable<EquipeCadastroViewModel>)Session["address"]).ToList();

            equipeBusiness.RemoverTodasEquipes(idProgramacao);

            foreach (var e in a)
            {
                Equipe equipe = Mapper.Map<Equipe>(e);
                equipe.EQP_PRO_IDENTIFICADOR = idProgramacao;
                equipe.EQP_USU_IDENTIFICADOR = Convert.ToInt32(((Usuario)Session["usuarioLogado"]).USU_IDENTIFICADOR);

                equipeBusiness.CadastrarEquipe(equipe);
            }
        }

        [Authorization("ADM", "CON")]
        public ActionResult Edicao(int PRO_IDENTIFICADOR)
        {
            ProgramacaoEdicaoViewModel model = new ProgramacaoEdicaoViewModel();

            try
            {
                model = Mapper.Map<ProgramacaoEdicaoViewModel>(business.ConsultarProgramacaoPorId(PRO_IDENTIFICADOR));

            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [Authorization("ADM", "CON")]
        [HttpPost]
        public ActionResult Edicao(ProgramacaoEdicaoViewModel model)
        {
            if (model.PRO_IMPEDIMENTO == "1")
            {
                model.PRO_DATA_PROGRAMACAO = null;
                model.PRO_HORA_INICIO_PROGRAMACAO = null;
                model.PRO_HORA_TERMINO_PROGRAMACAO = null;
                model.PRO_QUANTIDADE_A_PROGRAMAR = null;
                model.PRO_DESLIGAMENTO = "0";
                model.PRO_HORA_INICIO_SGD = null;
                model.PRO_HORA_TERMINO_SGD = null;
                model.PRO_NUMERO_SGD = null;
                model.PRO_RECURSO_BIG_JUMPER = false;
                model.PRO_RECURSO_CHAVE_PROVISORIA = false;
                model.PRO_RECURSO_GERADOR = false;
                model.PRO_RECURSO_INTERLIGACAO_REDE = false;
                model.PRO_RECURSO_LINHA_VIVA = false;
                model.PRO_RECURSO_SEM_RECURSO = true;
            }
            else if (model.PRO_IMPEDIMENTO == "0")
            {
                model.PRO_MOTIVO = "12";
            }

            model.PRO_USU_IDENTIFICADOR = Convert.ToInt32(((Usuario)Session["usuarioLogado"]).USU_IDENTIFICADOR);

            if (Session["address"] == null)
            {
                Session["address"] = new List<EquipeCadastroViewModel>(); ;
            }

            ModelState.Clear();

            var equipes = (IEnumerable<EquipeCadastroViewModel>)Session["address"];

            if ((model.PRO_IMPEDIMENTO == "0") && (equipes.FirstOrDefault() == null))
            {
                ModelState.AddModelError("erro_inserir_equipe", "É necessário ao menos uma equipe para gravar.");
            }

            //TODO: ver com o Victor -validação
            //if (ModelState.IsValid)
            if (
                   //impedimento = SIM
                   (
                        (model.PRO_IMPEDIMENTO == "1") &&
                        (!string.IsNullOrEmpty(model.PRO_MOTIVO)) &&
                        (Convert.ToInt16(model.PRO_MOTIVO) != 12) &&
                        (model.PRO_RECURSO_SEM_RECURSO)
                   ) ||
                   //impedimento = NÃO
                   (
                        //(equipes.Any()) &&
                        (equipes.Count() > 0) &&
                        (model.PRO_IMPEDIMENTO == "0") &&
                        (model.PRO_DATA_PROGRAMACAO >= DateTime.Now.Date) &&
                        (model.PRO_HORA_TERMINO_PROGRAMACAO > model.PRO_HORA_INICIO_PROGRAMACAO) &&
                        (!string.IsNullOrEmpty(model.PRO_QUANTIDADE_A_PROGRAMAR)) &&
                        (!string.IsNullOrEmpty(model.PRO_DESLIGAMENTO)) &&
                        (!string.IsNullOrEmpty(model.PRO_DISPOSITIVO)) &&
                        (model.PRO_QUANTIDADE_CLIENTE >= 0) &&
                        (!string.IsNullOrEmpty(model.PRO_IMPACTO_CONH)) &&
                        (!string.IsNullOrEmpty(model.PRO_IMPACTO_CONI)) &&
                        (
                            (model.PRO_RECURSO_BIG_JUMPER) ||
                            (model.PRO_RECURSO_CHAVE_PROVISORIA) ||
                            (model.PRO_RECURSO_GERADOR) ||
                            (model.PRO_RECURSO_INTERLIGACAO_REDE) ||
                            (model.PRO_RECURSO_LINHA_VIVA) ||
                            (model.PRO_RECURSO_SEM_RECURSO)
                        )
                   )
               )
            {
                try
                {
                    //TODO: voltar aki para resolver
//                    model.PRO_DESLIGAMENTO = "0";

                    Programacao programacao = Mapper.Map<Programacao>(model);

                    business.AtualizarProgramacao(programacao);

                    CadastrarEquipes(programacao.PRO_IDENTIFICADOR);

                    TempData["Mensagem"] = $"Programação para o dispositivo {programacao.PRO_DISPOSITIVO ?? programacao.Planejamento.PLA_DISPOSITIVO}, atualizado com sucesso.";
                    ModelState.Clear();

                    string url = Url.Action("ConsultaDadosProgramacao", "Planejamento", new { PLA_DISPOSITIVO = programacao.Planejamento.PLA_DISPOSITIVO, PLA_PROJETO = programacao.Planejamento.PLA_PROJETO, ConsultarProgramacao = true });
                    //var url = "~/Planejamento/ConsultaDadosProgramacao?PLA_DISPOSITIVO=" + programacao.Planejamento.PLA_DISPOSITIVO + "&PLA_PROJETO=" + programacao.Planejamento.PLA_PROJETO + "&ConsultarProgramacao=true";

                    return Redirect(url);
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }
            else
            {
                TempData["Mensagem"] = @" Campos obrigatórios não foram preenchidos ou preenchidos incorretamente. ";
            }

            return View(model);
        }
    }
}
