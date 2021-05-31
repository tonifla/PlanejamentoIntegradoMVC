using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.BLL;
using Projeto.Entities;

namespace Projeto.Presentation.Models
{
    public class PlanejamentoConsultaPIPViewModel
    {
        public int PLA_IDENTIFICADOR { get; set; }

        public string PLA_RANKING_FEC_INICIAL { get; set; }

        public string PLA_RANKING_FEC_ATUAL { get; set; }

        public string PLA_RANKING_DEC_INICIAL { get; set; }

        public string PLA_RANKING_DEC_ATUAL { get; set; }

        public string PLA_RANKING_FEC_INICIAL_CONJ { get; set; }

        public string PLA_RANKING_FEC_ATUAL_CONJ { get; set; }

        public string PLA_RANKING_DEC_INICIAL_CONJ { get; set; }

        public string PLA_RANKING_DEC_ATUAL_CONJ { get; set; }

        public string PLA_RANKING_FEC_INICIAL_REGION { get; set; }

        public string PLA_RANKING_FEC_ATUAL_REGION { get; set; }

        public string PLA_RANKING_DEC_INICIAL_REGION { get; set; }

        public string PLA_RANKING_DEC_ATUAL_REGION { get; set; }

        public string PLA_CAUSA_FEC_INICIAL { get; set; }

        public string PLA_CAUSA_FEC_ATUAL { get; set; }

        public string PLA_CAUSA_DEC_INICIAL { get; set; }

        public string PLA_CAUSA_DEC_ATUAL { get; set; }

        public string PLA_CAUSA_FEC_INICIAL_CONJ { get; set; }

        public string PLA_CAUSA_FEC_ATUAL_CONJ { get; set; }

        public string PLA_CAUSA_DEC_INICIAL_CONJ { get; set; }

        public string PLA_CAUSA_DEC_ATUAL_CONJ { get; set; }

        public string PLA_CAUSA_FEC_INICIAL_REGION { get; set; }

        public string PLA_CAUSA_FEC_ATUAL_REGION { get; set; }

        public string PLA_CAUSA_DEC_INICIAL_REGION { get; set; }

        public string PLA_CAUSA_DEC_ATUAL_REGION { get; set; }

        public string PLA_EVOLUCAO_FEC { get; set; }

        public string PLA_EVOLUCAO_DEC { get; set; }

        public string PLA_RANKING_CLIENTE { get; set; }

        public string PLA_REGIONAL { get; set; }

        public string PLA_BASE { get; set; }

        public string PLA_CONJUNTO { get; set; }

        public string PLA_ALIMENTADOR { get; set; }

        public string PLA_DISPOSITIVO { get; set; }

        public string PLA_TIPO_DISPOSITIVO { get; set; }

        public string PLA_ACAO { get; set; }

        public string PLA_UNIDADE { get; set; }

        public string PLA_PROJETO { get; set; }

        public string PLA_QUANTIDADE_EXECUTADA { get; set; }

        public string PLA_DATA_META_CONCLUSAO { get; set; }

        public string PLA_DATA_DE_EXECUCAO { get; set; }

        public string PLA_STATUS_EXECUCAO1 { get; set; }

        public string PLA_QUANTIDADE_PLANO_ATUAL { get; set; }

        public string PLA_QUADRIMESTRE_EXECUTAR { get; set; }

        public string PLA_AVANCO { get; set; }

        public string PLA_QUANTIDADE_PENDENTE { get; set; }

        public string PLA_PROCESSO { get; set; }

        public string PLA_DATA_CADASTRO { get; set; }

        public string PLA_PARCEIRA_EXECUCAO { get; set; }

        public string PLA_ALOCACAO_RECURSO { get; set; }

        public string PLA_QUANTIDADE_RECURSO { get; set; }

        public string PLA_STATUS_PROGRAMACAO { get; set; }

        public string PLA_DATA_PROGRAMADA_EXECUCAO { get; set; }

        public string PLA_STATUS_EXECUCAO2 { get; set; }

        public string PLA_DATA_REAL_EXECUCAO_ETAPA { get; set; }

        public string PLA_NECESSARIO_DESLIG_PROGRAMA { get; set; }

        public string PLA_META_PROGRAMADA_CONH_MES { get; set; }

        public string PLA_META_PROGRAMADA_CONI_MES { get; set; }

        public string PLA_META_PROGRAMADA_CONH_DIA { get; set; }

        public string PLA_META_PROGRAMADA_CONI_DIA { get; set; }

        public string PLA_HORA_INICIO_OBRA { get; set; }

        public string PLA_HORA_TERMINO_OBRA { get; set; }

        public string PLA_COMPARTILHAMENTO_ESTRUTURA { get; set; }

        public string PLA_COMPARTILHAMENTO_SGD { get; set; }

        public string PLA_UTILIZACAO_RECURSO { get; set; }

        public string PLA_NUMERO_SGD { get; set; }

        public string PLA_HORA_PREVISTA_INICIO_SGD { get; set; }

        public string PLA_HORA_PREVISTA_TERMINO_SGD { get; set; }

        public string PLA_QUANTIDADE_CLIENTE_AFETADO { get; set; }

        public string PLA_MOTIVO_CANCELAMENTO { get; set; }

        public string PLA_OBSERVACAO_CANCELAMENTO { get; set; }

        public string PLA_EXISTE_IMPEDIMENTO_PROGRAM { get; set; }

        public string PLA_QTD_SERVICOS_DISPOSITIVO { get; set; }

        public string PLA_DISPOSITIVO_PENDENTE_PRO { get; set; }

        public string PLA_CLIENTES_FATURADOS { get; set; }

        public string PLA_CLIENTES_INSTALADOS { get; set; }

        public string PLA_TOTAL_CLIENTES { get; set; }

        public string PLA_POTENCIAL_IMPACTO { get; set; }

        public string PLA_POTENCIAL_IMPACTO_CONJUNTO { get; set; }

        public string PLA_POTENCIAL_IMPACTO_REGIONAL { get; set; }

        public string PLA_DEC_TAM_2019 { get; set; }

        public string PLA_FEC_TAM_2019 { get; set; }

        public string PLA_DEC_META_ANEEL_2019 { get; set; }

        public string PLA_FEC_META_ANEEL_2019 { get; set; }

        public string PLA_META_DEC_TAM_140 { get; set; }

        public string PLA_META_FEC_TAM_122 { get; set; }

        public string PLA_DESVIO_DEC { get; set; }

        public string PLA_DESVIO_FEC { get; set; }

        public string PLA_GAP_CONH_DEZ_ANEEL { get; set; }

        public string PLA_GAP_CONI_DEZ_ANEEL { get; set; }

        public string PLA_ESTADO_CONJUNTO_DEC_LIMITE { get; set; }

        public string PLA_ESTADO_CONJUNTO_FEC_LIMITE { get; set; }

        public string PLA_POTENCIAL_SERVICO_CONH_MES { get; set; }

        public string PLA_POTENCIAL_SERVICO_CONI_MES { get; set; }

        public string PLA_PROJECAO_IMPACTO_PROG_CONH { get; set; }

        public string PLA_PROJECAO_IMPACTO_PROG_CONI { get; set; }

        public string PLA_PROJECAO_MELHORIA_CONH_MES { get; set; }

        public string PLA_PROJECAO_MELHORIA_CONI_MES { get; set; }

        public string PLA_VALOR_TOTAL { get; set; }

        public string PLA_LOCAL { get; set; }

        public string PLA_ESTADO_CONJUNTO { get; set; }

        public string PLA_POSSUI_RANK { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string PLA_POLO { get; set; }

        public string PLA_CLI_AFE_REF_INICIAL { get; set; }

        public string PLA_CLI_AFE_REF_ATUAL { get; set; }

        public string PLA_CLI_X_TEMP_REF_INICIAL { get; set; }

        public string PLA_CLI_X_TEMP_REF_ATUAL { get; set; }
    }
}