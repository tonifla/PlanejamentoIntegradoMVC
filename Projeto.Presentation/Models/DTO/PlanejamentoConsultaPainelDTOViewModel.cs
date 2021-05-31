using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Models.DTO
{
    public class PlanejamentoConsultaPainelDTOViewModel
    {
        public List<PlanejamentoConsultaPainelViewModel> ConsultaPlanejamentoList { get; set; }

        public List<ProgramacaoConsultaViewModel> ConsultaProgramacaoList { get; set; }

        #region DropDownList

        public string PLA_REGIONAL { get; set; }
        public List<SelectListItem> RegionaisList { get; set; }

        public string PLA_PROCESSO { get; set; }
        public List<SelectListItem> ProcessosList { get; set; }

        public string TIP_TIPO_PROCESSO { get; set; }
        public List<SelectListItem> TiposDeProcessosList { get; set; }

        public string EstadoDoConjunto { get; set; }
        public List<SelectListItem> EstadosDosConjuntosList { get; set; }

        public string PLA_CONJUNTO { get; set; }
        public List<SelectListItem> ConjuntosList { get; set; }

        public string PLA_STATUS_PROGRAMACAO { get; set; }
        public List<SelectListItem> StatusDasProgramacoesList { get; set; }

        [DisplayName("Tronco")]
        public bool LocalTronco { get; set; }

        [DisplayName("Ramal")]
        public bool LocalRamal { get; set; }

        public bool RealizarConsulta { get; set; }


        public string PLA_PROJETO { get; set; }
        public List<SelectListItem> ProjetosList { get; set; }

        public string PLA_IDENTIFICADOR { get; set; }
        public string OTCorrecao { get; set; }
        public string PLA_ALIMENTADOR { get; set; }
        public string PLA_DISPOSITIVO { get; set; }
        public string PLA_ACAO { get; set; }
        public string PLA_UNIDADE { get; set; }
        public string PLA_TOTAL_CLIENTES { get; set; }
        public string PLA_QUANTIDADE_PLANO_ATUAL { get; set; }
        public string PLA_QUANTIDADE_PENDENTE { get; set; }
        public string PLA_GAP_CONH_DEZ_ANEEL { get; set; }
        public string PLA_GAP_CONI_DEZ_ANEEL { get; set; }
        public bool ConsultarProgramacao { get; set; }
        #endregion
    }
}