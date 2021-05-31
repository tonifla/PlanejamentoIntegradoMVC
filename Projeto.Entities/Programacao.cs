using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Programacao
    {
        public int PRO_IDENTIFICADOR { get; set; }
        public string PRO_IMPEDIMENTO { get; set; }
        public string PRO_MOTIVO { get; set; }
        public string PRO_STATUS { get; set; }
        public DateTime? PRO_DATA_PROGRAMACAO { get; set; }
        public DateTime? PRO_HORA_INICIO_PROGRAMACAO { get; set; }
        public DateTime? PRO_HORA_TERMINO_PROGRAMACAO { get; set; }
        public string PRO_QUANTIDADE_A_PROGRAMAR { get; set; }
        public string PRO_OBSERVACAO { get; set; }
        public string PRO_DESLIGAMENTO { get; set; }
        public string PRO_DISPOSITIVO { get; set; }
        public int PRO_QUANTIDADE_CLIENTE { get; set; }
        public DateTime? PRO_HORA_INICIO_SGD { get; set; }
        public DateTime? PRO_HORA_TERMINO_SGD { get; set; }
        public int? PRO_NUMERO_SGD { get; set; }
        public string PRO_IMPACTO_CONH { get; set; }
        public string PRO_IMPACTO_CONI { get; set; }
        public int PRO_RECURSO_BIG_JUMPER { get; set; }
        public int PRO_RECURSO_CHAVE_PROVISORIA { get; set; }
        public int PRO_RECURSO_GERADOR { get; set; }
        public int PRO_RECURSO_INTERLIGACAO_REDE { get; set; }
        public int PRO_RECURSO_LINHA_VIVA { get; set; }
        public int PRO_RECURSO_SEM_RECURSO { get; set; }
        public int PRO_PLA_IDENTIFICADOR { get; set; }
        public int PRO_USU_IDENTIFICADOR { get; set; }
        public int IMP_IDENTIFICADOR { get; set; }
        public string IMP_DESCRICAO { get; set; }


        public Planejamento Planejamento { get; set; }
        public List<Equipe> Equipes { get; set; }

        public Programacao()
        {
                
        }

        public Programacao(int pRO_IDENTIFICADOR, string pRO_IMPEDIMENTO, string pRO_MOTIVO, string pRO_STATUS, DateTime pRO_DATA_PROGRAMACAO, DateTime pRO_HORA_INICIO_PROGRAMACAO, DateTime pRO_HORA_TERMINO_PROGRAMACAO, string pRO_QUANTIDADE_A_PROGRAMAR, string pRO_OBSERVACAO, string pRO_DESLIGAMENTO, string pRO_DISPOSITIVO, int pRO_QUANTIDADE_CLIENTE, DateTime pRO_HORA_INICIO_SGD, DateTime pRO_HORA_TERMINO_SGD, int pRO_NUMERO_SGD, string pRO_IMPACTO_CONH, string pRO_IMPACTO_CONI, int pRO_RECURSO_BIG_JUMPER, int pRO_RECURSO_CHAVE_PROVISORIA, int pRO_RECURSO_GERADOR, int pRO_RECURSO_INTERLIGACAO_REDE, int pRO_RECURSO_LINHA_VIVA, int pRO_RECURSO_SEM_RECURSO, int pRO_PLA_IDENTIFICADOR, int pRO_USU_IDENTIFICADOR, int iMP_IDENTIFICADOR, string iMP_DESCRICAO)
        {
            PRO_IDENTIFICADOR = pRO_IDENTIFICADOR;
            PRO_IMPEDIMENTO = pRO_IMPEDIMENTO;
            PRO_MOTIVO = pRO_MOTIVO;
            PRO_STATUS = pRO_STATUS;
            PRO_DATA_PROGRAMACAO = pRO_DATA_PROGRAMACAO;
            PRO_HORA_INICIO_PROGRAMACAO = pRO_HORA_INICIO_PROGRAMACAO;
            PRO_HORA_TERMINO_PROGRAMACAO = pRO_HORA_TERMINO_PROGRAMACAO;
            PRO_QUANTIDADE_A_PROGRAMAR = pRO_QUANTIDADE_A_PROGRAMAR;
            PRO_OBSERVACAO = pRO_OBSERVACAO;
            PRO_DESLIGAMENTO = pRO_DESLIGAMENTO;
            PRO_DISPOSITIVO = pRO_DISPOSITIVO;
            PRO_QUANTIDADE_CLIENTE = pRO_QUANTIDADE_CLIENTE;
            PRO_HORA_INICIO_SGD = pRO_HORA_INICIO_SGD;
            PRO_HORA_TERMINO_SGD = pRO_HORA_TERMINO_SGD;
            PRO_NUMERO_SGD = pRO_NUMERO_SGD;
            PRO_IMPACTO_CONH = pRO_IMPACTO_CONH;
            PRO_IMPACTO_CONI = pRO_IMPACTO_CONI;
            PRO_RECURSO_BIG_JUMPER = pRO_RECURSO_BIG_JUMPER;
            PRO_RECURSO_CHAVE_PROVISORIA = pRO_RECURSO_CHAVE_PROVISORIA;
            PRO_RECURSO_GERADOR = pRO_RECURSO_GERADOR;
            PRO_RECURSO_INTERLIGACAO_REDE = pRO_RECURSO_INTERLIGACAO_REDE;
            PRO_RECURSO_LINHA_VIVA = pRO_RECURSO_LINHA_VIVA;
            PRO_RECURSO_SEM_RECURSO = pRO_RECURSO_SEM_RECURSO;
            PRO_PLA_IDENTIFICADOR = pRO_PLA_IDENTIFICADOR;
            PRO_USU_IDENTIFICADOR = pRO_USU_IDENTIFICADOR;
            IMP_IDENTIFICADOR = iMP_IDENTIFICADOR;
            IMP_DESCRICAO = iMP_DESCRICAO;
        }

        public override string ToString()
        {
            return $"Id: {PRO_IDENTIFICADOR}, Impedimento: {PRO_IMPEDIMENTO}, Motivo: {PRO_MOTIVO}, Status: {PRO_STATUS}, DataProgramacao: {PRO_DATA_PROGRAMACAO}, HoraInicioProgramacao: {PRO_HORA_INICIO_PROGRAMACAO}, HoraTerminoProgramacao: {PRO_HORA_TERMINO_PROGRAMACAO}, QuantidadeAProgramar: {PRO_QUANTIDADE_A_PROGRAMAR}, Observacao: {PRO_OBSERVACAO}, Desligamento: {PRO_DESLIGAMENTO}, Dispositivo: {PRO_DISPOSITIVO}, QuantidadeCliente: {PRO_QUANTIDADE_CLIENTE}, HoraInicioSGD: {PRO_HORA_INICIO_SGD}, HoraTerminoSGD: {PRO_HORA_TERMINO_SGD}, NumeroSGD: {PRO_NUMERO_SGD}, ImpactoCONH: {PRO_IMPACTO_CONH}, ImpactoCONI: {PRO_IMPACTO_CONI}, RecursoBigJumper: {PRO_RECURSO_BIG_JUMPER}, RecursoChaveProvisorio: {PRO_RECURSO_CHAVE_PROVISORIA}, RecursoGerador: {PRO_RECURSO_GERADOR}, RecursoInterligacaoRede: {PRO_RECURSO_INTERLIGACAO_REDE}, RecursoLinhaViva: {PRO_RECURSO_LINHA_VIVA}, RecursoSemRecurso: {PRO_RECURSO_SEM_RECURSO}, IdPlanejamento: {PRO_PLA_IDENTIFICADOR}, IdUsuario: {PRO_USU_IDENTIFICADOR}, IdMotivoImpedimento: {IMP_IDENTIFICADOR}, MotivoImpedimento: {IMP_DESCRICAO}";
        }
    }
}
