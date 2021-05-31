using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class EquipeConsultaViewModel
    {
        public int EQP_IDENTIFICADOR { get; set; }

        [DisplayName("TIPO EQUIPE")]
        public string EQP_TIPO_EQUIPE { get; set; }

        [DisplayName("DESCRIÇÃO")]
        public string EQP_DESCRICAO { get; set; }

        [DisplayName("QUANTIDADE")]
        public int? EQP_QUANTIDADE { get; set; }

        [DisplayName("PARCEIRA")]
        public string EQP_PARCEIRA { get; set; }

        public int EQP_PRO_IDENTIFICADOR { get; set; }

        public int EQP_USU_IDENTIFICADOR { get; set; }

        public string PLA_REGIONAL { get; set; }
    }
}