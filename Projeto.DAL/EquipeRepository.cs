using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Projeto.Entities;
using Oracle.ManagedDataAccess.Client;
using Dapper;
using System.Data.OleDb;
using System.Data;

namespace Projeto.DAL
{
    public class EquipeRepository
    {

        private string connectionString;

        public EquipeRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoPIP"].ConnectionString;
        }

        public void Insert(Equipe equipe)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" INSERT INTO EQUIPE(EQP_IDENTIFICADOR,
                                                   EQP_TIPO_EQUIPE,
                                                   EQP_DESCRICAO,
                                                   EQP_QUANTIDADE,
                                                   EQP_PARCEIRA,
                                                   EQP_PRO_IDENTIFICADOR,
                                                   EQP_USU_IDENTIFICADOR,
                                                   EQP_ATIVO)
                                VALUES(EQUIPE_SEQ.NEXTVAL,
                                       :EQP_TIPO_EQUIPE,
                                       :EQP_DESCRICAO,
                                       :EQP_QUANTIDADE,
                                       :EQP_PARCEIRA,
                                       :EQP_PRO_IDENTIFICADOR,
                                       :EQP_USU_IDENTIFICADOR,
                                       :EQP_ATIVO) ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                conn.Execute(query, equipe);
                conn.Close();
            }
        }

        public void Update(Equipe equipe)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" UPDATE EQUIPE
                                SET EQP_TIPO_EQUIPE            = :EQP_TIPO_EQUIPE,
                                    EQP_DESCRICAO              = :EQP_DESCRICAO,
                                    EQP_QUANTIDADE             = :EQP_QUANTIDADE,
                                    EQP_PARCEIRA               = :EQP_PARCEIRA,
                                    EQP_PRO_IDENTIFICADOR      = :EQP_PRO_IDENTIFICADOR,
                                    EQP_USU_IDENTIFICADOR      = :EQP_USU_IDENTIFICADOR
                                WHERE EQP_IDENTIFICADOR = :EQP_IDENTIFICADOR ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();
                conn.Execute(query, equipe);
                conn.Close();
            }
        }

        public void DeleteAll(int idProgramacao)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" DELETE FROM EQUIPE
                                WHERE EQP_PRO_IDENTIFICADOR = '{idProgramacao}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();
                conn.Execute(query);
                conn.Close();
            }
        }

        public void Delete(int idEquipe)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" DELETE FROM EQUIPE
                                WHERE EQP_IDENTIFICADOR = '{idEquipe}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();
                conn.Execute(query);
                conn.Close();
            }
        }

        public List<Equipe> SelectByTiposDeEquipesPorRecurso(string regional)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT REC_TIPO_EQUIPE
                                FROM RECURSO
                                WHERE REC_REGIONAL    = '{regional}'
                                ORDER BY REC_TIPO_EQUIPE ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();

                //object result = cmd.ExecuteScalar();
                cmd.ExecuteScalar();

                return conn.Query<Equipe>(query).ToList();
            }
        }

        public List<Equipe> SelectByDescricoesPorRecurso(string regional,
                                                         string tipoDeEquipe)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT REC_DESCRICAO
                                FROM RECURSO
                                WHERE REC_REGIONAL    = '{regional}'
                                  AND REC_TIPO_EQUIPE = '{tipoDeEquipe}'
                                ORDER BY REC_DESCRICAO ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();

                //object result = cmd.ExecuteScalar();
                cmd.ExecuteScalar();

                return conn.Query<Equipe>(query).ToList();
            }
        }

        public int SelectByQuantidadePorRecurso(string regional,
                                                string tipoDeEquipe,
                                                string descricao)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT REC_TOTAL
                                FROM RECURSO
                                WHERE REC_REGIONAL    = '{regional}'
                                  AND REC_TIPO_EQUIPE = '{tipoDeEquipe}'
                                  AND REC_DESCRICAO   = '{descricao}'
                                ORDER BY REC_TOTAL ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();

                //object result = cmd.ExecuteScalar();
                cmd.ExecuteScalar();

                return conn.Query<int>(query).SingleOrDefault();
            }
        }

        public List<Equipe> SelectByParceiraPorRecurso(string regional,
                                                       string tipoDeEquipe,
                                                       string descricao,
                                                       int quantidade)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT ' - ' REC_PARCEIRA
                                FROM RECURSO
                                WHERE REC_REGIONAL    = '{regional}'
                                  AND REC_TIPO_EQUIPE = '{tipoDeEquipe}'
                                  AND REC_DESCRICAO   = '{descricao}'
                                  AND REC_TOTAL       = '{quantidade}'
                                ORDER BY REC_PARCEIRA ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();

                //object result = cmd.ExecuteScalar();
                cmd.ExecuteScalar();

                return conn.Query<Equipe>(query).ToList();
            }
        }

        public Equipe SelectById(int id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT *
                                FROM EQUIPE EQP
                                INNER JOIN PROGRAMACAO PRO   ON EQP.EQP_PRO_IDENTIFICADOR = PRO.PRO_IDENTIFICADOR
                                INNER JOIN PLANEJAMENTO PLA  ON PLA.PLA_IDENTIFICADOR     = PRO.PRO_PLA_IDENTIFICADOR
                                WHERE EQP.EQP_IDENTIFICADOR = '{id}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Equipe>(query).SingleOrDefault();

                //TODO: verificar dps com o Victor
                //return conn.Query
                //    (query, (Equipe eqp, Programacao pro) =>
                //    {
                //        eqp.Programacao = pro;
                //        return eqp;
                //    },
                //    new { EQP_IDENTIFICADOR = id },
                //splitOn: "PRO_IDENTIFICADOR")
                //    .SingleOrDefault();

            }
        }


        public List<Equipe> SelectEquipesByIdProgramacao(int id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT *
                                FROM EQUIPE EQP
                                INNER JOIN PROGRAMACAO PRO   ON EQP.EQP_PRO_IDENTIFICADOR = PRO.PRO_IDENTIFICADOR
                                INNER JOIN PLANEJAMENTO PLA  ON PLA.PLA_IDENTIFICADOR     = PRO.PRO_PLA_IDENTIFICADOR
                                WHERE EQP_PRO_IDENTIFICADOR = {id} ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                //return conn.Query<Programacao>(query).ToList();
                //return conn.Query<Programacao>(query).SingleOrDefault();

                return conn.Query<Equipe>(query).ToList();

                //TODO: verificar dps com o Victor
                //return conn.Query
                //    (query, (Equipe eqp, Programacao pro, Planejamento pla) =>
                //    {
                //        eqp.Programacao = pro;
                //        eqp.Planejamento = pla;
                //        return eqp;
                //    },
                //    new { EQP_PRO_IDENTIFICADOR = id },
                //splitOn: "PRO_IDENTIFICADOR, PLA_IDENTIFICADOR")
                //    .ToList();
            }
        }
    }
}