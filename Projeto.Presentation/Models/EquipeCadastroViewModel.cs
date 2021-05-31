using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.Entities;

namespace Projeto.Presentation.Models
{
    public class EquipeCadastroViewModel
    {
        public EquipeCadastroViewModel()
        {
            EQP_ATIVO = 1;
        }

        [Required(ErrorMessage = "Campo obrigatório (Tipo de equipe)")]
        [Display(Name = "TIPO EQUIPE")]
        public string EQP_TIPO_EQUIPE { get; set; }

        [Display(Name = "DESCRIÇÃO")]
        [Required(ErrorMessage = "Campo obrigatório (Descrição)")]
        public string EQP_DESCRICAO { get; set; }

        [Display(Name = "QUANTIDADE")]
        [Required(ErrorMessage = "Campo obrigatório (Quantidade)")]
        public int? EQP_QUANTIDADE { get; set; }

        [Display(Name = "PARCEIRA")]
        //TODO: verificar dps com o cliente
        [Required(ErrorMessage = "Campo obrigatório (Parceira)")]
        public string EQP_PARCEIRA { get; set; }

        public int EQP_PRO_IDENTIFICADOR { get; set; }

        public int EQP_IDENTIFICADOR { get; set; }

        public int EQP_USU_IDENTIFICADOR { get; set; }

        public int EQP_ATIVO { get; set; }

        public string PLA_REGIONAL { get; set; }

        public bool PodeRemover
        {
            get
            {
                var usuarioLogado = HttpContext.Current.Session["usuarioLogado"] as Usuario;

                if (usuarioLogado != null)
                {
                    var perfilLogado = usuarioLogado.Perfis.Any(x => x.Tipo == PerfilEnum.ADMINISTRADOR) ? PerfilEnum.ADMINISTRADOR : PerfilEnum.CONSULTOR;

                    return perfilLogado == PerfilEnum.ADMINISTRADOR || EQP_IDENTIFICADOR == 0;
                }

                return false;
            }
        }

        public bool PodeDesabilitar
        {
            get
            {
                return EQP_IDENTIFICADOR != 0;
            }
        }

        public List<EquipeCadastroViewModel> ConsultaEquipeList { get; set; }
        public List<SelectListItem> TiposDeEquipeList { get; set; }
        public List<SelectListItem> DescricoesList { get; set; }
        public int QuantidadesList { get; set; }
        public List<SelectListItem> ParceirasList { get; set; }
    }
}