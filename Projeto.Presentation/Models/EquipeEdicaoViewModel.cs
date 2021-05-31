using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.BLL;
using AutoMapper;
using Projeto.Entities;

namespace Projeto.Presentation.Models
{
    public class EquipeEdicaoViewModel
    {
        public int EQP_IDENTIFICADOR { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Tipo de equipe)")]
        public string EQP_TIPO_EQUIPE { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Descrição)")]
        public string EQP_DESCRICAO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Quantidade)")]
        public int? EQP_QUANTIDADE { get; set; }

        //TODO: verificar dps com o cliente
        //[Required(ErrorMessage = "Campo obrigatório (Parceira)")]
        public string EQP_PARCEIRA { get; set; }

        public int EQP_PRO_IDENTIFICADOR { get; set; }

        public int EQP_USU_IDENTIFICADOR { get; set; }

        public string PLA_REGIONAL { get; set; }

        public List<SelectListItem> TiposDeEquipeList
        {
            get
            {
                EquipeBusiness business = new EquipeBusiness();

                var lista = new List<SelectListItem>
                { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

                foreach (var item in business.ConsultarTiposDeEquipesPorRecurso(PLA_REGIONAL)) lista.Add(new SelectListItem()
                { Text = item.REC_TIPO_EQUIPE, Value = item.REC_TIPO_EQUIPE });

                return lista;
            }
        }

        public List<SelectListItem> DescricoesList
        {
            get
            {
                EquipeBusiness business = new EquipeBusiness();

                var lista = new List<SelectListItem>
                { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

                foreach (var item in business.ConsultarDescricoesPorRecurso(PLA_REGIONAL, EQP_TIPO_EQUIPE)) lista.Add(new SelectListItem()
                { Text = item.REC_DESCRICAO, Value = item.REC_DESCRICAO });

                return lista;
            }
        }

        public int QuantidadesList
        {
            get
            {
                EquipeBusiness business = new EquipeBusiness();

                return business.ConsultarQuantidadePorRecurso(PLA_REGIONAL, EQP_TIPO_EQUIPE, EQP_DESCRICAO);
            }
        }

        public List<SelectListItem> ParceirasList
        {
            get
            {
                EquipeBusiness business = new EquipeBusiness();

                var lista = new List<SelectListItem>
                { new SelectListItem() { Text = "Escolha uma opção", Value = "" } };

                //foreach (var item in business.ConsultarParceiraPorRecurso(PLA_REGIONAL, EQP_TIPO_EQUIPE, EQP_DESCRICAO, EQP_QUANTIDADE)) lista.Add(new SelectListItem()
                //{ Text = "", Value = "" });

                return lista;
            }
        }
    }
}