using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Planejamento
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
        public string PLA_POLO { get; set; }
        public string PLA_CLI_AFE_REF_INICIAL { get; set; }
        public string PLA_CLI_AFE_REF_ATUAL { get; set; }
        public string PLA_CLI_X_TEMP_REF_INICIAL { get; set; }
        public string PLA_CLI_X_TEMP_REF_ATUAL { get; set; }

        public string TMP_TIPO_PROCESSO { get; set; }
        public string TMP_ESTADO_CONJUNTO_DEC_FEC { get; set; }
        public bool TMP_LOCAL_TRONCO { get; set; }
        public bool TMP_LOCAL_RAMAL { get; set; }
        public bool TMP_LOCAL_VAZIO { get; set; }
        public int PLA_QTDE_LOCAL { get; set; }
        public int? PLA_QTDE_DIAS_VENCIMENTO { get; set; }

        public List<Programacao> Programacoes { get; set; }

        public Planejamento()
        {
        }

        public Planejamento(int pLA_IDENTIFICADOR, string pLA_RANKING_FEC_INICIAL, string pLA_RANKING_FEC_ATUAL, string pLA_RANKING_DEC_INICIAL, string pLA_RANKING_DEC_ATUAL, string pLA_RANKING_FEC_INICIAL_CONJ, string pLA_RANKING_FEC_ATUAL_CONJ, string pLA_RANKING_DEC_INICIAL_CONJ, string pLA_RANKING_DEC_ATUAL_CONJ, string pLA_RANKING_FEC_INICIAL_REGION, string pLA_RANKING_FEC_ATUAL_REGION, string pLA_RANKING_DEC_INICIAL_REGION, string pLA_RANKING_DEC_ATUAL_REGION, string pLA_CAUSA_FEC_INICIAL, string pLA_CAUSA_FEC_ATUAL, string pLA_CAUSA_DEC_INICIAL, string pLA_CAUSA_DEC_ATUAL, string pLA_CAUSA_FEC_INICIAL_CONJ, string pLA_CAUSA_FEC_ATUAL_CONJ, string pLA_CAUSA_DEC_INICIAL_CONJ, string pLA_CAUSA_DEC_ATUAL_CONJ, string pLA_CAUSA_FEC_INICIAL_REGION, string pLA_CAUSA_FEC_ATUAL_REGION, string pLA_CAUSA_DEC_INICIAL_REGION, string pLA_CAUSA_DEC_ATUAL_REGION, string pLA_EVOLUCAO_FEC, string pLA_EVOLUCAO_DEC, string pLA_RANKING_CLIENTE, string pLA_REGIONAL, string pLA_BASE, string pLA_CONJUNTO, string pLA_ALIMENTADOR, string pLA_DISPOSITIVO, string pLA_TIPO_DISPOSITIVO, string pLA_ACAO, string pLA_UNIDADE, string pLA_PROJETO, string pLA_QUANTIDADE_EXECUTADA, string pLA_DATA_META_CONCLUSAO, string pLA_DATA_DE_EXECUCAO, string pLA_STATUS_EXECUCAO1, string pLA_QUANTIDADE_PLANO_ATUAL, string pLA_QUADRIMESTRE_EXECUTAR, string pLA_AVANCO, string pLA_QUANTIDADE_PENDENTE, string pLA_PROCESSO, string pLA_DATA_CADASTRO, string pLA_PARCEIRA_EXECUCAO, string pLA_ALOCACAO_RECURSO, string pLA_QUANTIDADE_RECURSO, string pLA_STATUS_PROGRAMACAO, string pLA_DATA_PROGRAMADA_EXECUCAO, string pLA_STATUS_EXECUCAO2, string pLA_DATA_REAL_EXECUCAO_ETAPA, string pLA_NECESSARIO_DESLIG_PROGRAMA, string pLA_META_PROGRAMADA_CONH_MES, string pLA_META_PROGRAMADA_CONI_MES, string pLA_META_PROGRAMADA_CONH_DIA, string pLA_META_PROGRAMADA_CONI_DIA, string pLA_HORA_INICIO_OBRA, string pLA_HORA_TERMINO_OBRA, string pLA_COMPARTILHAMENTO_ESTRUTURA, string pLA_COMPARTILHAMENTO_SGD, string pLA_UTILIZACAO_RECURSO, string pLA_NUMERO_SGD, string pLA_HORA_PREVISTA_INICIO_SGD, string pLA_HORA_PREVISTA_TERMINO_SGD, string pLA_QUANTIDADE_CLIENTE_AFETADO, string pLA_MOTIVO_CANCELAMENTO, string pLA_OBSERVACAO_CANCELAMENTO, string pLA_EXISTE_IMPEDIMENTO_PROGRAM, string pLA_QTD_SERVICOS_DISPOSITIVO, string pLA_DISPOSITIVO_PENDENTE_PRO, string pLA_CLIENTES_FATURADOS, string pLA_CLIENTES_INSTALADOS, string pLA_TOTAL_CLIENTES, string pLA_POTENCIAL_IMPACTO, string pLA_POTENCIAL_IMPACTO_CONJUNTO, string pLA_POTENCIAL_IMPACTO_REGIONAL, string pLA_DEC_TAM_2019, string pLA_FEC_TAM_2019, string pLA_DEC_META_ANEEL_2019, string pLA_FEC_META_ANEEL_2019, string pLA_META_DEC_TAM_140, string pLA_META_FEC_TAM_122, string pLA_DESVIO_DEC, string pLA_DESVIO_FEC, string pLA_GAP_CONH_DEZ_ANEEL, string pLA_GAP_CONI_DEZ_ANEEL, string pLA_ESTADO_CONJUNTO_DEC_LIMITE, string pLA_ESTADO_CONJUNTO_FEC_LIMITE, string pLA_POTENCIAL_SERVICO_CONH_MES, string pLA_POTENCIAL_SERVICO_CONI_MES, string pLA_PROJECAO_IMPACTO_PROG_CONH, string pLA_PROJECAO_IMPACTO_PROG_CONI, string pLA_PROJECAO_MELHORIA_CONH_MES, string pLA_PROJECAO_MELHORIA_CONI_MES, string pLA_VALOR_TOTAL, string pLA_LOCAL, string pLA_ESTADO_CONJUNTO, string pLA_POSSUI_RANK, string pLA_POLO, string pLA_CLI_AFE_REF_INICIAL, string pLA_CLI_AFE_REF_ATUAL, string pLA_CLI_X_TEMP_REF_INICIAL, string pLA_CLI_X_TEMP_REF_ATUAL, string tMP_TIPO_PROCESSO, string tMP_ESTADO_CONJUNTO_DEC_FEC, bool tMP_LOCAL_TRONCO, bool tMP_LOCAL_RAMAL, bool tMP_LOCAL_VAZIO, int pLA_QTDE_LOCAL, int pLA_QTDE_DIAS_VENCIMENTO)
        {
            PLA_IDENTIFICADOR = pLA_IDENTIFICADOR;
            PLA_RANKING_FEC_INICIAL = pLA_RANKING_FEC_INICIAL;
            PLA_RANKING_FEC_ATUAL = pLA_RANKING_FEC_ATUAL;
            PLA_RANKING_DEC_INICIAL = pLA_RANKING_DEC_INICIAL;
            PLA_RANKING_DEC_ATUAL = pLA_RANKING_DEC_ATUAL;
            PLA_RANKING_FEC_INICIAL_CONJ = pLA_RANKING_FEC_INICIAL_CONJ;
            PLA_RANKING_FEC_ATUAL_CONJ = pLA_RANKING_FEC_ATUAL_CONJ;
            PLA_RANKING_DEC_INICIAL_CONJ = pLA_RANKING_DEC_INICIAL_CONJ;
            PLA_RANKING_DEC_ATUAL_CONJ = pLA_RANKING_DEC_ATUAL_CONJ;
            PLA_RANKING_FEC_INICIAL_REGION = pLA_RANKING_FEC_INICIAL_REGION;
            PLA_RANKING_FEC_ATUAL_REGION = pLA_RANKING_FEC_ATUAL_REGION;
            PLA_RANKING_DEC_INICIAL_REGION = pLA_RANKING_DEC_INICIAL_REGION;
            PLA_RANKING_DEC_ATUAL_REGION = pLA_RANKING_DEC_ATUAL_REGION;
            PLA_CAUSA_FEC_INICIAL = pLA_CAUSA_FEC_INICIAL;
            PLA_CAUSA_FEC_ATUAL = pLA_CAUSA_FEC_ATUAL;
            PLA_CAUSA_DEC_INICIAL = pLA_CAUSA_DEC_INICIAL;
            PLA_CAUSA_DEC_ATUAL = pLA_CAUSA_DEC_ATUAL;
            PLA_CAUSA_FEC_INICIAL_CONJ = pLA_CAUSA_FEC_INICIAL_CONJ;
            PLA_CAUSA_FEC_ATUAL_CONJ = pLA_CAUSA_FEC_ATUAL_CONJ;
            PLA_CAUSA_DEC_INICIAL_CONJ = pLA_CAUSA_DEC_INICIAL_CONJ;
            PLA_CAUSA_DEC_ATUAL_CONJ = pLA_CAUSA_DEC_ATUAL_CONJ;
            PLA_CAUSA_FEC_INICIAL_REGION = pLA_CAUSA_FEC_INICIAL_REGION;
            PLA_CAUSA_FEC_ATUAL_REGION = pLA_CAUSA_FEC_ATUAL_REGION;
            PLA_CAUSA_DEC_INICIAL_REGION = pLA_CAUSA_DEC_INICIAL_REGION;
            PLA_CAUSA_DEC_ATUAL_REGION = pLA_CAUSA_DEC_ATUAL_REGION;
            PLA_EVOLUCAO_FEC = pLA_EVOLUCAO_FEC;
            PLA_EVOLUCAO_DEC = pLA_EVOLUCAO_DEC;
            PLA_RANKING_CLIENTE = pLA_RANKING_CLIENTE;
            PLA_REGIONAL = pLA_REGIONAL;
            PLA_BASE = pLA_BASE;
            PLA_CONJUNTO = pLA_CONJUNTO;
            PLA_ALIMENTADOR = pLA_ALIMENTADOR;
            PLA_DISPOSITIVO = pLA_DISPOSITIVO;
            PLA_TIPO_DISPOSITIVO = pLA_TIPO_DISPOSITIVO;
            PLA_ACAO = pLA_ACAO;
            PLA_UNIDADE = pLA_UNIDADE;
            PLA_PROJETO = pLA_PROJETO;
            PLA_QUANTIDADE_EXECUTADA = pLA_QUANTIDADE_EXECUTADA;
            PLA_DATA_META_CONCLUSAO = pLA_DATA_META_CONCLUSAO;
            PLA_DATA_DE_EXECUCAO = pLA_DATA_DE_EXECUCAO;
            PLA_STATUS_EXECUCAO1 = pLA_STATUS_EXECUCAO1;
            PLA_QUANTIDADE_PLANO_ATUAL = pLA_QUANTIDADE_PLANO_ATUAL;
            PLA_QUADRIMESTRE_EXECUTAR = pLA_QUADRIMESTRE_EXECUTAR;
            PLA_AVANCO = pLA_AVANCO;
            PLA_QUANTIDADE_PENDENTE = pLA_QUANTIDADE_PENDENTE;
            PLA_PROCESSO = pLA_PROCESSO;
            PLA_DATA_CADASTRO = pLA_DATA_CADASTRO;
            PLA_PARCEIRA_EXECUCAO = pLA_PARCEIRA_EXECUCAO;
            PLA_ALOCACAO_RECURSO = pLA_ALOCACAO_RECURSO;
            PLA_QUANTIDADE_RECURSO = pLA_QUANTIDADE_RECURSO;
            PLA_STATUS_PROGRAMACAO = pLA_STATUS_PROGRAMACAO;
            PLA_DATA_PROGRAMADA_EXECUCAO = pLA_DATA_PROGRAMADA_EXECUCAO;
            PLA_STATUS_EXECUCAO2 = pLA_STATUS_EXECUCAO2;
            PLA_DATA_REAL_EXECUCAO_ETAPA = pLA_DATA_REAL_EXECUCAO_ETAPA;
            PLA_NECESSARIO_DESLIG_PROGRAMA = pLA_NECESSARIO_DESLIG_PROGRAMA;
            PLA_META_PROGRAMADA_CONH_MES = pLA_META_PROGRAMADA_CONH_MES;
            PLA_META_PROGRAMADA_CONI_MES = pLA_META_PROGRAMADA_CONI_MES;
            PLA_META_PROGRAMADA_CONH_DIA = pLA_META_PROGRAMADA_CONH_DIA;
            PLA_META_PROGRAMADA_CONI_DIA = pLA_META_PROGRAMADA_CONI_DIA;
            PLA_HORA_INICIO_OBRA = pLA_HORA_INICIO_OBRA;
            PLA_HORA_TERMINO_OBRA = pLA_HORA_TERMINO_OBRA;
            PLA_COMPARTILHAMENTO_ESTRUTURA = pLA_COMPARTILHAMENTO_ESTRUTURA;
            PLA_COMPARTILHAMENTO_SGD = pLA_COMPARTILHAMENTO_SGD;
            PLA_UTILIZACAO_RECURSO = pLA_UTILIZACAO_RECURSO;
            PLA_NUMERO_SGD = pLA_NUMERO_SGD;
            PLA_HORA_PREVISTA_INICIO_SGD = pLA_HORA_PREVISTA_INICIO_SGD;
            PLA_HORA_PREVISTA_TERMINO_SGD = pLA_HORA_PREVISTA_TERMINO_SGD;
            PLA_QUANTIDADE_CLIENTE_AFETADO = pLA_QUANTIDADE_CLIENTE_AFETADO;
            PLA_MOTIVO_CANCELAMENTO = pLA_MOTIVO_CANCELAMENTO;
            PLA_OBSERVACAO_CANCELAMENTO = pLA_OBSERVACAO_CANCELAMENTO;
            PLA_EXISTE_IMPEDIMENTO_PROGRAM = pLA_EXISTE_IMPEDIMENTO_PROGRAM;
            PLA_QTD_SERVICOS_DISPOSITIVO = pLA_QTD_SERVICOS_DISPOSITIVO;
            PLA_DISPOSITIVO_PENDENTE_PRO = pLA_DISPOSITIVO_PENDENTE_PRO;
            PLA_CLIENTES_FATURADOS = pLA_CLIENTES_FATURADOS;
            PLA_CLIENTES_INSTALADOS = pLA_CLIENTES_INSTALADOS;
            PLA_TOTAL_CLIENTES = pLA_TOTAL_CLIENTES;
            PLA_POTENCIAL_IMPACTO = pLA_POTENCIAL_IMPACTO;
            PLA_POTENCIAL_IMPACTO_CONJUNTO = pLA_POTENCIAL_IMPACTO_CONJUNTO;
            PLA_POTENCIAL_IMPACTO_REGIONAL = pLA_POTENCIAL_IMPACTO_REGIONAL;
            PLA_DEC_TAM_2019 = pLA_DEC_TAM_2019;
            PLA_FEC_TAM_2019 = pLA_FEC_TAM_2019;
            PLA_DEC_META_ANEEL_2019 = pLA_DEC_META_ANEEL_2019;
            PLA_FEC_META_ANEEL_2019 = pLA_FEC_META_ANEEL_2019;
            PLA_META_DEC_TAM_140 = pLA_META_DEC_TAM_140;
            PLA_META_FEC_TAM_122 = pLA_META_FEC_TAM_122;
            PLA_DESVIO_DEC = pLA_DESVIO_DEC;
            PLA_DESVIO_FEC = pLA_DESVIO_FEC;
            PLA_GAP_CONH_DEZ_ANEEL = pLA_GAP_CONH_DEZ_ANEEL;
            PLA_GAP_CONI_DEZ_ANEEL = pLA_GAP_CONI_DEZ_ANEEL;
            PLA_ESTADO_CONJUNTO_DEC_LIMITE = pLA_ESTADO_CONJUNTO_DEC_LIMITE;
            PLA_ESTADO_CONJUNTO_FEC_LIMITE = pLA_ESTADO_CONJUNTO_FEC_LIMITE;
            PLA_POTENCIAL_SERVICO_CONH_MES = pLA_POTENCIAL_SERVICO_CONH_MES;
            PLA_POTENCIAL_SERVICO_CONI_MES = pLA_POTENCIAL_SERVICO_CONI_MES;
            PLA_PROJECAO_IMPACTO_PROG_CONH = pLA_PROJECAO_IMPACTO_PROG_CONH;
            PLA_PROJECAO_IMPACTO_PROG_CONI = pLA_PROJECAO_IMPACTO_PROG_CONI;
            PLA_PROJECAO_MELHORIA_CONH_MES = pLA_PROJECAO_MELHORIA_CONH_MES;
            PLA_PROJECAO_MELHORIA_CONI_MES = pLA_PROJECAO_MELHORIA_CONI_MES;
            PLA_VALOR_TOTAL = pLA_VALOR_TOTAL;
            PLA_LOCAL = pLA_LOCAL;
            PLA_ESTADO_CONJUNTO = pLA_ESTADO_CONJUNTO;
            PLA_POSSUI_RANK = pLA_POSSUI_RANK;
            PLA_POLO = pLA_POLO;
            PLA_CLI_AFE_REF_INICIAL = pLA_CLI_AFE_REF_INICIAL;
            PLA_CLI_AFE_REF_ATUAL = pLA_CLI_AFE_REF_ATUAL;
            PLA_CLI_X_TEMP_REF_INICIAL = pLA_CLI_X_TEMP_REF_INICIAL;
            PLA_CLI_X_TEMP_REF_ATUAL = pLA_CLI_X_TEMP_REF_ATUAL;
            TMP_TIPO_PROCESSO = tMP_TIPO_PROCESSO;
            TMP_ESTADO_CONJUNTO_DEC_FEC = tMP_ESTADO_CONJUNTO_DEC_FEC;
            TMP_LOCAL_TRONCO = tMP_LOCAL_TRONCO;
            TMP_LOCAL_RAMAL = tMP_LOCAL_RAMAL;
            TMP_LOCAL_VAZIO = tMP_LOCAL_VAZIO;
            PLA_QTDE_LOCAL = pLA_QTDE_LOCAL;
            PLA_QTDE_DIAS_VENCIMENTO = pLA_QTDE_DIAS_VENCIMENTO;
        }

        public override string ToString()
        {
            return $"Id: {PLA_IDENTIFICADOR}, RankingFECInicial: {PLA_RANKING_FEC_INICIAL}, RankingFECAtual: {PLA_RANKING_FEC_ATUAL}, RankingDECInicial: {PLA_RANKING_DEC_INICIAL}, RankingDECAtual: {PLA_RANKING_DEC_ATUAL}, RankingFECInicialConjunto: {PLA_RANKING_FEC_INICIAL_CONJ}, RankingFECAtualConjunto: {PLA_RANKING_FEC_ATUAL_CONJ}, RankingDECInicialConjunto: {PLA_RANKING_DEC_INICIAL_CONJ}, RankingDECAtualConjunto: {PLA_RANKING_DEC_ATUAL_CONJ}, RankingFECInicialRegional: {PLA_RANKING_FEC_INICIAL_REGION}, RankingFECAtualRegional: {PLA_RANKING_FEC_ATUAL_REGION}, RankingDECInicialRegional: {PLA_RANKING_DEC_INICIAL_REGION}, RankingDECAtualRegional: {PLA_RANKING_DEC_ATUAL_REGION}, CausaFECInicial: {PLA_CAUSA_FEC_INICIAL}, CausaFECAtual: {PLA_CAUSA_FEC_ATUAL}, CausaDECInicial: {PLA_CAUSA_DEC_INICIAL}, CausaDECAtual: {PLA_CAUSA_DEC_ATUAL}, CausaFECInicialConjunto: {PLA_CAUSA_FEC_INICIAL_CONJ}, CausaFECAtualConjunto: {PLA_CAUSA_FEC_ATUAL_CONJ}, CausaDECInicialConjunto: {PLA_CAUSA_DEC_INICIAL_CONJ}, CausaDECAtualConjunto: {PLA_CAUSA_DEC_ATUAL_CONJ}, CausaFECInicialRegional: {PLA_CAUSA_FEC_INICIAL_REGION}, CausaFECAtualRegional: {PLA_CAUSA_FEC_ATUAL_REGION}, CausaDECInicialRegional: {PLA_CAUSA_DEC_INICIAL_REGION}, CausaDECAtualRegional: {PLA_CAUSA_DEC_ATUAL_REGION}, EvolucaoFEC: {PLA_EVOLUCAO_FEC}, EvolucaoDEC: {PLA_EVOLUCAO_DEC}, RankingCliente: {PLA_RANKING_CLIENTE}, Regional: {PLA_REGIONAL}, Base: {PLA_BASE}, Conjunto: {PLA_CONJUNTO}, Alimentador: {PLA_ALIMENTADOR}, Dispositivo: {PLA_DISPOSITIVO}, TipoDispositivo: {PLA_TIPO_DISPOSITIVO}, Acao: {PLA_ACAO}, Unidade: {PLA_UNIDADE}, Projeto: {PLA_PROJETO}, QuantidadeExetutada: {PLA_QUANTIDADE_EXECUTADA}, DataMetaConclusao: {PLA_DATA_META_CONCLUSAO}, DataExecucao: {PLA_DATA_DE_EXECUCAO}, StatusExecucao1: {PLA_STATUS_EXECUCAO1}, QuantidadePlanoAtual: {PLA_QUANTIDADE_PLANO_ATUAL}, QuadrimestreExecutar: {PLA_QUADRIMESTRE_EXECUTAR}, Avanco: {PLA_AVANCO}, QuantidadePendente: {PLA_QUANTIDADE_PENDENTE}, Processo: {PLA_PROCESSO}, DataCadastro: {PLA_DATA_CADASTRO}, ParceiraExecucao: {PLA_PARCEIRA_EXECUCAO}, AlocacaoRecurso: {PLA_ALOCACAO_RECURSO}, QuantidadeRecurso: {PLA_QUANTIDADE_RECURSO}, StatusProgramacao: {PLA_STATUS_PROGRAMACAO}, DataProgramadaExecucao: {PLA_DATA_PROGRAMADA_EXECUCAO}, StatusExecucao2: {PLA_STATUS_EXECUCAO2}, DataRealExecucaoEtapa: {PLA_DATA_REAL_EXECUCAO_ETAPA}, NecessarioDesligamentoProgramado: {PLA_NECESSARIO_DESLIG_PROGRAMA}, MetaProgramadaCONHMes: {PLA_META_PROGRAMADA_CONH_MES}, MetaProgramadaCONIMes: {PLA_META_PROGRAMADA_CONI_MES}, MetaProgramadaCONHDiario: {PLA_META_PROGRAMADA_CONH_DIA}, MetaProgramadaCONIDiario: {PLA_META_PROGRAMADA_CONI_DIA}, HoraInicioObra: {PLA_HORA_INICIO_OBRA}, HoraTerminoObra: {PLA_HORA_TERMINO_OBRA}, CompartilhamentoEstrutura: {PLA_COMPARTILHAMENTO_ESTRUTURA}, CompartilhamentoSGD: {PLA_COMPARTILHAMENTO_SGD}, UtilizacaoRecurso: {PLA_UTILIZACAO_RECURSO}, NumeroSGD: {PLA_NUMERO_SGD}, HoraPrevistaInicioSGD: {PLA_HORA_PREVISTA_INICIO_SGD}, HoraPrevistaTerminoSGD: {PLA_HORA_PREVISTA_TERMINO_SGD}, QuantidadeClienteAfetado: {PLA_QUANTIDADE_CLIENTE_AFETADO}, MotivoCancelamento: {PLA_MOTIVO_CANCELAMENTO}, ObservacaoCancelamento: {PLA_OBSERVACAO_CANCELAMENTO}, ExisteImpedimentoProgramacao: {PLA_EXISTE_IMPEDIMENTO_PROGRAM}, QuantidadeServicosDispositivo: {PLA_QTD_SERVICOS_DISPOSITIVO}, DispositivoPendenteProgramacao: {PLA_DISPOSITIVO_PENDENTE_PRO}, ClientesFaturados: {PLA_CLIENTES_FATURADOS}, ClientesInstalados: {PLA_CLIENTES_INSTALADOS}, TotalClientes: {PLA_TOTAL_CLIENTES}, PotencialImpacto: {PLA_POTENCIAL_IMPACTO}, PotencialImpactoConjunto: {PLA_POTENCIAL_IMPACTO_CONJUNTO}, PotencialImpactoRegional: {PLA_POTENCIAL_IMPACTO_REGIONAL}, DECTAM2019: {PLA_DEC_TAM_2019}, FECTAM2019: {PLA_FEC_TAM_2019}, DECMetaANEEL2019: {PLA_DEC_META_ANEEL_2019}, FECMetaANEEL2019: {PLA_FEC_META_ANEEL_2019}, MetaDECTAM140: {PLA_META_DEC_TAM_140}, MetaFECTAM122: {PLA_META_FEC_TAM_122}, DesvioDEC: {PLA_DESVIO_DEC}, DesvioFEC: {PLA_DESVIO_FEC}, GapCONHDezANEEL: {PLA_GAP_CONH_DEZ_ANEEL}, GapCONIDezANEEL: {PLA_GAP_CONI_DEZ_ANEEL}, EstadoConjuntoDECLimite: {PLA_ESTADO_CONJUNTO_DEC_LIMITE}, EstadoConjuntoFECLimite: {PLA_ESTADO_CONJUNTO_FEC_LIMITE}, PotencialServicoCONHMes: {PLA_POTENCIAL_SERVICO_CONH_MES}, PotencialServicoCONIMes: {PLA_POTENCIAL_SERVICO_CONI_MES}, ProjecaoImpactoProgramacaoCONH: {PLA_PROJECAO_IMPACTO_PROG_CONH}, ProjecaoImpactoProgramacaoCONI: {PLA_PROJECAO_IMPACTO_PROG_CONI}, ProjecaoMelhoriaCONHMes: {PLA_PROJECAO_MELHORIA_CONH_MES}, ProjecaoMelhoriaCONIMes: {PLA_PROJECAO_MELHORIA_CONI_MES}, ValorTotal: {PLA_VALOR_TOTAL}, Local: {PLA_LOCAL}, EstadoConjunto: {PLA_ESTADO_CONJUNTO}, PossuiRank: {PLA_POSSUI_RANK}, Polo: {PLA_POLO}, ClienteAfetadoReferenciaInicial: {PLA_CLI_AFE_REF_INICIAL}, ClienteAfetadoReferenciaAtual: {PLA_CLI_AFE_REF_ATUAL}, ClienteTempoReferenciaInicial: {PLA_CLI_X_TEMP_REF_INICIAL}, ClienteTempoReferenciaAtual: {PLA_CLI_X_TEMP_REF_ATUAL }, TipoProcesso: { TMP_TIPO_PROCESSO }, EstadoConjuntoDEC_FEC: { TMP_ESTADO_CONJUNTO_DEC_FEC}, LocalTronco: { TMP_LOCAL_TRONCO }, LocalRamal: { TMP_LOCAL_RAMAL }, LocalVazio: { TMP_LOCAL_VAZIO }, QuantidadeLocal: { PLA_QTDE_LOCAL }, QuantidadeDiasVencimento: { PLA_QTDE_DIAS_VENCIMENTO }";
        }
    }
}