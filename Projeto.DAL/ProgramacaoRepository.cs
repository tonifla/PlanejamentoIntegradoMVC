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
    public class ProgramacaoRepository
    {
        private string connectionString;

        public ProgramacaoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoPIP"].ConnectionString;
        }

        public int Insert(Programacao programacao)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var queryId = $@" SELECT PROGRAMACAO_SEQ.NEXTVAL FROM DUAL ";

                OracleCommand cmdId = new OracleCommand(queryId, conn);
                cmdId.BindByName = true;

                conn.Open();
                cmdId.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                programacao.PRO_IDENTIFICADOR = conn.Query<int>(queryId).SingleOrDefault();


                var query = $@" INSERT INTO PROGRAMACAO(PRO_IDENTIFICADOR,
                                                        PRO_IMPEDIMENTO,
                                                        PRO_MOTIVO,
                                                        PRO_STATUS,
                                                        PRO_DATA_PROGRAMACAO,
                                                        PRO_HORA_INICIO_PROGRAMACAO,
                                                        PRO_HORA_TERMINO_PROGRAMACAO,
                                                        PRO_QUANTIDADE_A_PROGRAMAR,
                                                        PRO_OBSERVACAO,
                                                        PRO_DESLIGAMENTO,
                                                        PRO_DISPOSITIVO,
                                                        PRO_QUANTIDADE_CLIENTE,
                                                        PRO_HORA_INICIO_SGD,
                                                        PRO_HORA_TERMINO_SGD,
                                                        PRO_NUMERO_SGD,
                                                        PRO_IMPACTO_CONH,
                                                        PRO_IMPACTO_CONI,
                                                        PRO_RECURSO_BIG_JUMPER,
                                                        PRO_RECURSO_CHAVE_PROVISORIA,
                                                        PRO_RECURSO_GERADOR,
                                                        PRO_RECURSO_INTERLIGACAO_REDE,
                                                        PRO_RECURSO_LINHA_VIVA,
                                                        PRO_RECURSO_SEM_RECURSO,
                                                        PRO_PLA_IDENTIFICADOR,
                                                        PRO_USU_IDENTIFICADOR)
                                VALUES(:PRO_IDENTIFICADOR,
                                       :PRO_IMPEDIMENTO,
                                       :PRO_MOTIVO,
                                       :PRO_STATUS,
                                       :PRO_DATA_PROGRAMACAO,
                                       :PRO_HORA_INICIO_PROGRAMACAO,
                                       :PRO_HORA_TERMINO_PROGRAMACAO,
                                       :PRO_QUANTIDADE_A_PROGRAMAR,
                                       :PRO_OBSERVACAO,
                                       :PRO_DESLIGAMENTO,
                                       :PRO_DISPOSITIVO,
                                       :PRO_QUANTIDADE_CLIENTE,
                                       :PRO_HORA_INICIO_SGD,
                                       :PRO_HORA_TERMINO_SGD,
                                       :PRO_NUMERO_SGD,
                                       :PRO_IMPACTO_CONH,
                                       :PRO_IMPACTO_CONI,
                                       :PRO_RECURSO_BIG_JUMPER,
                                       :PRO_RECURSO_CHAVE_PROVISORIA,
                                       :PRO_RECURSO_GERADOR,
                                       :PRO_RECURSO_INTERLIGACAO_REDE,
                                       :PRO_RECURSO_LINHA_VIVA,
                                       :PRO_RECURSO_SEM_RECURSO,
                                       :PRO_PLA_IDENTIFICADOR,
                                       :PRO_USU_IDENTIFICADOR) ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                //cmd.Parameters.Add(new OracleParameter("PRO_IMPEDIMENTO", 1));
                //cmd.Parameters.Add(new OracleParameter("PRO_MOTIVO", 1));
                
                //não é para abrir conexão novamente
                //conn.Open();
                conn.Execute(query, programacao);
                conn.Close();

                return programacao.PRO_IDENTIFICADOR;
            }
        }

        public void Update(Programacao programacao)
        {
            if (programacao.PRO_PLA_IDENTIFICADOR == 0 && programacao.Planejamento != null)
            {
                programacao.PRO_PLA_IDENTIFICADOR = programacao.Planejamento.PLA_IDENTIFICADOR;

                if (string.IsNullOrEmpty(programacao.PRO_DISPOSITIVO))
                {
                    programacao.PRO_DISPOSITIVO = programacao.Planejamento.PLA_DISPOSITIVO;
                }

                if (programacao.PRO_QUANTIDADE_CLIENTE <= 0)
                {
                    if (string.IsNullOrEmpty(programacao.Planejamento.PLA_TOTAL_CLIENTES))
                    {
                        programacao.PRO_QUANTIDADE_CLIENTE = 0;
                    }
                    else
                    {
                        programacao.PRO_QUANTIDADE_CLIENTE = Convert.ToInt32(programacao.Planejamento.PLA_TOTAL_CLIENTES);
                    }
                }

                if (string.IsNullOrEmpty(programacao.PRO_IMPACTO_CONH))
                {
                    if (string.IsNullOrEmpty(programacao.Planejamento.PLA_GAP_CONH_DEZ_ANEEL))
                    {
                        programacao.PRO_IMPACTO_CONH = "0";
                    }
                    else
                    {
                        programacao.PRO_IMPACTO_CONH = programacao.Planejamento.PLA_GAP_CONH_DEZ_ANEEL;
                    }
                }

                if (string.IsNullOrEmpty(programacao.PRO_IMPACTO_CONI))
                {
                    if (string.IsNullOrEmpty(programacao.Planejamento.PLA_GAP_CONI_DEZ_ANEEL))
                    {
                        programacao.PRO_IMPACTO_CONI = "0";
                    }
                    else
                    {
                        programacao.PRO_IMPACTO_CONI = programacao.Planejamento.PLA_GAP_CONI_DEZ_ANEEL;
                    }
                }
            }


            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" UPDATE PROGRAMACAO
                                SET PRO_IMPEDIMENTO					= :PRO_IMPEDIMENTO,
                                    PRO_MOTIVO						= :PRO_MOTIVO,
                                    PRO_STATUS						= :PRO_STATUS,
                                    PRO_DATA_PROGRAMACAO		    = :PRO_DATA_PROGRAMACAO,
                                    PRO_HORA_INICIO_PROGRAMACAO		= :PRO_HORA_INICIO_PROGRAMACAO,
                                    PRO_HORA_TERMINO_PROGRAMACAO	= :PRO_HORA_TERMINO_PROGRAMACAO,
                                    PRO_QUANTIDADE_A_PROGRAMAR		= :PRO_QUANTIDADE_A_PROGRAMAR,
                                    PRO_OBSERVACAO					= :PRO_OBSERVACAO,
                                    PRO_DESLIGAMENTO				= :PRO_DESLIGAMENTO,
                                    PRO_DISPOSITIVO					= :PRO_DISPOSITIVO,
                                    PRO_QUANTIDADE_CLIENTE			= :PRO_QUANTIDADE_CLIENTE,
                                    PRO_HORA_INICIO_SGD				= :PRO_HORA_INICIO_SGD,
                                    PRO_HORA_TERMINO_SGD			= :PRO_HORA_TERMINO_SGD,
                                    PRO_NUMERO_SGD					= :PRO_NUMERO_SGD,
                                    PRO_IMPACTO_CONH				= :PRO_IMPACTO_CONH,
                                    PRO_IMPACTO_CONI				= :PRO_IMPACTO_CONI,
                                    PRO_RECURSO_BIG_JUMPER			= :PRO_RECURSO_BIG_JUMPER,
                                    PRO_RECURSO_CHAVE_PROVISORIA	= :PRO_RECURSO_CHAVE_PROVISORIA,
                                    PRO_RECURSO_GERADOR				= :PRO_RECURSO_GERADOR,
                                    PRO_RECURSO_INTERLIGACAO_REDE	= :PRO_RECURSO_INTERLIGACAO_REDE,
                                    PRO_RECURSO_LINHA_VIVA			= :PRO_RECURSO_LINHA_VIVA,
                                    PRO_RECURSO_SEM_RECURSO			= :PRO_RECURSO_SEM_RECURSO,
                                    PRO_PLA_IDENTIFICADOR			= :PRO_PLA_IDENTIFICADOR,
                                    PRO_USU_IDENTIFICADOR			= :PRO_USU_IDENTIFICADOR
                                WHERE PRO_PLA_IDENTIFICADOR = :PRO_PLA_IDENTIFICADOR
                                  AND PRO_IDENTIFICADOR = :PRO_IDENTIFICADOR ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                //cmd.Parameters.Add(new OracleParameter("PRO_IMPEDIMENTO", 1));
                //cmd.Parameters.Add(new OracleParameter("PRO_MOTIVO", 1));
                conn.Open();
                conn.Execute(query, programacao);
                conn.Close();
            }
        }

        public List<Programacao> SelectMotivosProgramacao()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM IMPEDIMENTO_PROGRAMACAO
                                ORDER BY IMP_DESCRICAO ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Programacao>(query).ToList();
            }
        }

        public List<Programacao> SelectProgramacoesByIdPlanejamento(string id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT *
                                FROM PROGRAMACAO
                                WHERE PRO_PLA_IDENTIFICADOR = '{id}'
                                ORDER BY PRO_DATA_PROGRAMACAO, PRO_HORA_INICIO_PROGRAMACAO DESC ";


                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Programacao>(query).ToList();
            }
        }

        public Programacao SelectProgramacaoById(int id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT *
                                FROM PROGRAMACAO PRO
                                INNER JOIN PLANEJAMENTO PLA ON PLA.PLA_IDENTIFICADOR = PRO.PRO_PLA_IDENTIFICADOR
                                WHERE PRO.PRO_IDENTIFICADOR = '{id}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                //return conn.Query<Programacao>(query).SingleOrDefault();

                return conn.Query
                    (query, (Programacao pro, Planejamento pla) =>
                    {
                        pro.Planejamento = pla;
                        return pro;
                    },
                    new { PRO_IDENTIFICADOR = id },
                splitOn: "PLA_IDENTIFICADOR")
                    .SingleOrDefault();
            }
        }
    }
}
