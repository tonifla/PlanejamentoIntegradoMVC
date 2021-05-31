using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Equipe
    {
        public int EQP_IDENTIFICADOR { get; set; }
        public string EQP_TIPO_EQUIPE { get; set; }
        public string EQP_DESCRICAO { get; set; }
        public int EQP_QUANTIDADE { get; set; }
        public string EQP_PARCEIRA { get; set; }
        public int EQP_PRO_IDENTIFICADOR { get; set; }
        public int EQP_USU_IDENTIFICADOR { get; set; }
        public int EQP_ATIVO { get; set; }

        public string REC_REGIONAL { get; set; }
        public string REC_TIPO_EQUIPE { get; set; }
        public string REC_DESCRICAO { get; set; }
        public int REC_TOTAL { get; set; }

        public string PLA_REGIONAL { get; set; }
        public Programacao Programacao { get; set; }
        public Planejamento Planejamento { get; set; }


        public Equipe()
        {

        }

        public Equipe(int eQP_IDENTIFICADOR, string eQP_TIPO_EQUIPE, string eQP_DESCRICAO, int eQP_QUANTIDADE, string eQP_PARCEIRA, int eQP_PRO_IDENTIFICADOR, int eQP_USU_IDENTIFICADOR, string rEC_REGIONAL, string rEC_TIPO_EQUIPE, string rEC_DESCRICAO, int rEC_TOTAL)
        {
            EQP_IDENTIFICADOR = eQP_IDENTIFICADOR;
            EQP_TIPO_EQUIPE = eQP_TIPO_EQUIPE;
            EQP_DESCRICAO = eQP_DESCRICAO;
            EQP_QUANTIDADE = eQP_QUANTIDADE;
            EQP_PARCEIRA = eQP_PARCEIRA;
            EQP_PRO_IDENTIFICADOR = eQP_PRO_IDENTIFICADOR;
            EQP_USU_IDENTIFICADOR = eQP_USU_IDENTIFICADOR;
            REC_REGIONAL = rEC_REGIONAL;
            REC_TIPO_EQUIPE = rEC_TIPO_EQUIPE;
            REC_DESCRICAO = rEC_DESCRICAO;
            REC_TOTAL = rEC_TOTAL;
        }

        public override string ToString()
        {
            return $"Id: { EQP_IDENTIFICADOR}, TipoEquipe: {EQP_TIPO_EQUIPE}, Descricao: {EQP_DESCRICAO}, Quantidade: {EQP_QUANTIDADE}, Parceira: {EQP_PARCEIRA}, RecursoRegional: {REC_REGIONAL}, RecursoTipoEquipe: {REC_TIPO_EQUIPE}, RecursoDescricao: {REC_DESCRICAO}, RecursoTotal: {REC_TOTAL}";
        }
    }
}
