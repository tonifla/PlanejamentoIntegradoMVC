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
    public class ProgramacaoCadastroViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório (Impedimento)")]
        public string PRO_IMPEDIMENTO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Motivo)")]
        public string PRO_MOTIVO { get; set; }

        public string PRO_STATUS { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        public DateTime? PRO_DATA_PROGRAMACAO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Hora em formato inválido")]
        public DateTime? PRO_HORA_INICIO_PROGRAMACAO { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Hora em formato inválido")]
        public DateTime? PRO_HORA_TERMINO_PROGRAMACAO { get; set; }

        [Range(0, 999.99)]
        public string PRO_QUANTIDADE_A_PROGRAMAR { get; set; }

        public string PRO_OBSERVACAO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Desligamento)")]
        public string PRO_DESLIGAMENTO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Dispositivo)")]
        public string PRO_DISPOSITIVO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Quantidade de clientes)")]
        public int PRO_QUANTIDADE_CLIENTE { get; set; }

        public int? PRO_NUMERO_SGD { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Hora em formato inválido")]
        public DateTime? PRO_HORA_INICIO_SGD { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.DateTime, ErrorMessage = "Hora em formato inválido")]
        public DateTime? PRO_HORA_TERMINO_SGD { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Impacto CONH)")]
        public string PRO_IMPACTO_CONH { get; set; }

        [Required(ErrorMessage = "Campo obrigatório (Impacto CONI)")]
        public string PRO_IMPACTO_CONI { get; set; }

        [DisplayName("Big Jumper")]
        public bool PRO_RECURSO_BIG_JUMPER { get; set; }

        [DisplayName("Chave Provisória")]
        public bool PRO_RECURSO_CHAVE_PROVISORIA { get; set; }

        [DisplayName("Gerador")]
        public bool PRO_RECURSO_GERADOR { get; set; }

        [DisplayName("Interligação de Rede")]
        public bool PRO_RECURSO_INTERLIGACAO_REDE { get; set; }

        [DisplayName("Linha Viva")]
        public bool PRO_RECURSO_LINHA_VIVA { get; set; }

        [DisplayName("Sem recurso")]
        public bool PRO_RECURSO_SEM_RECURSO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int PRO_USU_IDENTIFICADOR { get; set; }

        public int PRO_PLA_IDENTIFICADOR { get; set; }

        //informações originais do planejamento
        public string PLA_REGIONAL { get; set; }
        public string PLA_DISPOSITIVO { get; set; }
        public string PLA_PROJETO { get; set; }
        public string PLA_UNIDADE { get; set; }

        public PlanejamentoConsultaPainelViewModel Planejamento { get; set; }

        public IEnumerable<EquipeCadastroViewModel> Equipes { get; set; }

        public List<SelectListItem> MotivosList
        {
            get
            {
                ProgramacaoBusiness business = new ProgramacaoBusiness();
                List<Programacao> consulta = business.ConsultarMotivosProgramacao();

                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (Programacao programacao in consulta)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = programacao.IMP_IDENTIFICADOR.ToString();
                    item.Text = programacao.IMP_DESCRICAO;
                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}