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

namespace Projeto.Presentation.Controllers
{
    public class EquipeController : Controller
    {
        private EquipeBusiness business;

        public EquipeController()
        {
            business = new EquipeBusiness();
        }

        public ActionResult Consulta(string PLA_REGIONAL, ProgramacaoCadastroViewModel viewModel, int PRO_IDENTIFICADOR = 0)
        {
            ViewBag.PLA_REGIONAL = PLA_REGIONAL;

            // fornecendo o perfil mais baixo para quando a sessão morre
            ViewBag.PerfilLogado = PerfilEnum.CONSULTOR;

            var usuarioLogado = Session["usuarioLogado"] as Usuario;

            if (usuarioLogado != null)
            {
                ViewBag.PerfilLogado = usuarioLogado.Perfis.Any(x => x.Tipo == PerfilEnum.ADMINISTRADOR) ? PerfilEnum.ADMINISTRADOR : PerfilEnum.CONSULTOR;
            }

            if (PRO_IDENTIFICADOR != 0)
            {
               var lista = new List<EquipeCadastroViewModel>();

                try
                {
                    lista = Mapper.Map<List<EquipeCadastroViewModel>>(business.ConsultarEquipesPorIdProgramacao(PRO_IDENTIFICADOR));
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }

                Session["address"] = lista;               

                return PartialView("Consulta", lista);
            }
            else
            {
                var a = new List<EquipeCadastroViewModel>();

                if (Session["address"] == null)
                {
                    Session["address"] = a;
                }

                var addresses = (IEnumerable<EquipeCadastroViewModel>)Session["address"];

                //var addresses = db.Addresses.Where(a => a.PersonID == id).OrderBy(a => a.City);

                return PartialView("Consulta", addresses);
            }
        }

        public ActionResult Cadastro(string pla_regional, EquipeCadastroViewModel viewModel)
        {
            if (viewModel == null)
            {
                viewModel = new EquipeCadastroViewModel();
            }

            if (viewModel.TiposDeEquipeList == null)
            {
                viewModel.TiposDeEquipeList = ObterTiposDeEquipesPorRecurso(pla_regional);
                viewModel.DescricoesList = DescricaoPorRecurso(pla_regional, viewModel.EQP_TIPO_EQUIPE);
            }

            return PartialView("Cadastro", viewModel);
        }

        [HttpPost]
        public ActionResult Cadastro(EquipeCadastroViewModel equipe)
        {
            if (ModelState.IsValid)
            {
                var a = new List<EquipeCadastroViewModel>();

                if (Session["address"] == null)
                {
                    Session["address"] = a;
                }

                a = ((IEnumerable<EquipeCadastroViewModel>)Session["address"]).ToList();

                a.Add(equipe);

                //retornando a lista ao viewbag
                Session["address"] = a;

                string url = Url.Action("Consulta", "Equipe", new { PLA_REGIONAL = equipe.PLA_REGIONAL });
                return Json(new { success = true, url = url });
            }
            else
            {
                return Cadastro(equipe.PLA_REGIONAL, equipe);
            }
        }

        [HttpPost]
        public ActionResult Delete(string tipoEquipe, string descricao, string parceira)
        {
            var a = new List<EquipeCadastroViewModel>();

            if (Session["address"] == null)
            {
                Session["address"] = a;
            }

            a = ((IEnumerable<EquipeCadastroViewModel>)Session["address"]).ToList();

            var address = a.FirstOrDefault(x => x.EQP_TIPO_EQUIPE == tipoEquipe && x.EQP_DESCRICAO == descricao && x.EQP_PARCEIRA == parceira);

            var PLA_REGIONAL = address.PLA_REGIONAL;

            a.Remove(address);

            //retornando a lista ao viewbag
            Session["address"] = a;

            string url = Url.Action("Consulta", "Equipe", new { PLA_REGIONAL = PLA_REGIONAL });
            return Json(new { success = true, url = url });
        }

        [HttpPost]
        public ActionResult Desabilitar(string tipoEquipe, string descricao, string parceira)
        {
            var a = new List<EquipeCadastroViewModel>();

            if (Session["address"] == null)
            {
                Session["address"] = a;
            }

            a = ((IEnumerable<EquipeCadastroViewModel>)Session["address"]).ToList();

            var address = a.FirstOrDefault(x => x.EQP_TIPO_EQUIPE == tipoEquipe && x.EQP_DESCRICAO == descricao && x.EQP_PARCEIRA == parceira);
            
            var PLA_REGIONAL = address.PLA_REGIONAL;

            address.EQP_ATIVO = 0;
          
            //retornando a lista ao viewbag
            Session["address"] = a;

            string url = Url.Action("Consulta", "Equipe", new { PLA_REGIONAL = PLA_REGIONAL });
            return Json(new { success = true, url = url });
        }


        #region PRIVATE_METHODS_LISTAS

        private List<SelectListItem> ObterTiposDeEquipesPorRecurso(string regional)
        {
            var lista = new List<SelectListItem> { };

            if (!string.IsNullOrEmpty(regional))
            {
                foreach (var recurso in business.ConsultarTiposDeEquipesPorRecurso(regional)) lista.Add(new SelectListItem()
                { Text = recurso.REC_TIPO_EQUIPE, Value = recurso.REC_TIPO_EQUIPE });
            }
            return lista;
        }

        public JsonResult ObterDescricoesPorRecurso(string regional, string tipoDeEquipe)
        {
            List<SelectListItem> lista = DescricaoPorRecurso(regional, tipoDeEquipe);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> DescricaoPorRecurso(string regional, string tipoDeEquipe)
        {
            var lista = new List<SelectListItem> { };

            if (!string.IsNullOrEmpty(regional) && !string.IsNullOrEmpty(tipoDeEquipe))
            {
                foreach (var recurso in business.ConsultarDescricoesPorRecurso(regional, tipoDeEquipe)) lista.Add(new SelectListItem()
                { Text = recurso.REC_DESCRICAO, Value = recurso.REC_DESCRICAO });
            }

            return lista;
        }

        public JsonResult ObterQuantidadePorRecurso(string regional, string tipoDeEquipe, string descricao)
        {
            var quantidade = 0;

            if (!string.IsNullOrEmpty(regional) && !string.IsNullOrEmpty(tipoDeEquipe) && !string.IsNullOrEmpty(descricao))
            {
                quantidade = business.ConsultarQuantidadePorRecurso(regional, tipoDeEquipe, descricao);
            }

            return Json(quantidade, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterParceiraPorRecurso(string regional, string tipoDeEquipe, string descricao, int quantidade)
        {
            var lista = new List<SelectListItem> { };

            //TODO: ainda não tem definição de regra de parceiras
            //if (!string.IsNullOrEmpty(regional) && !string.IsNullOrEmpty(tipoDeEquipe) && !string.IsNullOrEmpty(descricao) && quantidade > 0)
            //{
            //    foreach (var recurso in business.ConsultarParceiraPorRecurso(regional, tipoDeEquipe, descricao, quantidade)) lista.Add(new SelectListItem()
            //    { Text = Convert.ToString(recurso.REC_), Value = Convert.ToString(recurso.REC_) });
            //}

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}