using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.BLL;
using Projeto.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Projeto.Presentation.Models
{
    public class ProgramacaoConsultaViewModel
    {
        [DisplayName("Id")]
        public int PRO_IDENTIFICADOR { get; set; }

        public string PRO_IMPEDIMENTO { get; set; }

        public string PRO_MOTIVO { get; set; }

        [DisplayName("Status")]
        public string PRO_STATUS { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data programação")]
        public DateTime? PRO_DATA_PROGRAMACAO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Início programação")]
        public DateTime? PRO_HORA_INICIO_PROGRAMACAO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Término programação")]
        public DateTime? PRO_HORA_TERMINO_PROGRAMACAO { get; set; }

        [DisplayName("Quantidade programada")]
        public string PRO_QUANTIDADE_A_PROGRAMAR { get; set; }

        public string PRO_OBSERVACAO { get; set; }

        public string PRO_DESLIGAMENTO { get; set; }

        public string PRO_DISPOSITIVO { get; set; }

        public int PRO_QUANTIDADE_CLIENTE { get; set; }

        public int? PRO_NUMERO_SGD { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? PRO_HORA_INICIO_SGD { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? PRO_HORA_TERMINO_SGD { get; set; }

        public string PRO_IMPACTO_CONH { get; set; }

        public string PRO_IMPACTO_CONI { get; set; }

        public bool PRO_RECURSO_BIG_JUMPER { get; set; }

        public bool PRO_RECURSO_CHAVE_PROVISORIA { get; set; }

        public bool PRO_RECURSO_GERADOR { get; set; }

        public bool PRO_RECURSO_INTERLIGACAO_REDE { get; set; }

        public bool PRO_RECURSO_LINHA_VIVA { get; set; }

        public bool PRO_RECURSO_SEM_RECURSO { get; set; }

        public int PRO_USU_IDENTIFICADOR { get; set; }

        public int PRO_PLA_IDENTIFICADOR { get; set; }
    }
}