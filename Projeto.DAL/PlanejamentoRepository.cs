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
    public class PlanejamentoRepository
    {
        private string connectionString;

        public PlanejamentoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoPIP"].ConnectionString;
        }

        public List<Planejamento> SelectByRegional()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT PLA_REGIONAL
                                FROM PLANEJAMENTO
                                ORDER BY PLA_REGIONAL ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                conn.Open();

                //object result = cmd.ExecuteScalar();
                cmd.ExecuteScalar();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByProcesso(string regional)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT PLA_PROCESSO
                                FROM PLANEJAMENTO
                                WHERE PLA_REGIONAL = '{regional}'
                                ORDER BY PLA_PROCESSO ";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByTipoProcesso(string processo)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT TIP_TIPO_PROCESSO TMP_TIPO_PROCESSO
                                FROM TIPO_PROCESSO
                                WHERE TIP_PROCESSO = '{processo}'
                                ORDER BY TIP_TIPO_PROCESSO ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByEstadoConjunto(string regional,
                                                         string processo,
                                                         string tipoDeProcesso)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT CASE WHEN 'DEC' = '{tipoDeProcesso}' THEN PLA_ESTADO_CONJUNTO_DEC_LIMITE
                                                     WHEN 'FEC' = '{tipoDeProcesso}' THEN PLA_ESTADO_CONJUNTO_FEC_LIMITE
                                                     ELSE ''
                                                END TMP_ESTADO_CONJUNTO_DEC_FEC
                                FROM PLANEJAMENTO
                                WHERE PLA_REGIONAL = '{regional}'
                                  AND PLA_PROCESSO = '{processo}'
                                ORDER BY TMP_ESTADO_CONJUNTO_DEC_FEC ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByConjunto(string regional,
                                                   string processo,
                                                   string tipoDeProcesso,
                                                   string estado)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query1 = $@" SELECT DISTINCT PLA_CONJUNTO
                                 FROM PLANEJAMENTO
                                 WHERE PLA_REGIONAL = '{regional}'
                                   AND PLA_PROCESSO = '{processo}' ";

                string query2;
                if (tipoDeProcesso == "DEC")
                {
                    query2 = $@"   AND PLA_ESTADO_CONJUNTO_DEC_LIMITE = '{estado}' ";
                }
                else if (tipoDeProcesso == "FEC")
                {
                    query2 = $@"   AND PLA_ESTADO_CONJUNTO_FEC_LIMITE = '{estado}' ";
                }
                else
                {
                    query2 = $@"   ";
                }

                var query3 = $@"  ORDER BY PLA_CONJUNTO ";

                var query = query1 + query2 + query3;

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByStatusProgramacao(string regional,
                                                            string processo,
                                                            string tipoDeProcesso)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT PLA.PLA_STATUS_PROGRAMACAO
                                FROM PLANEJAMENTO PLA
                                INNER JOIN TIPO_PROCESSO PRO
                                  ON PLA.PLA_PROCESSO = PRO.TIP_PROCESSO
                                WHERE PLA.PLA_REGIONAL = '{regional}'
                                  AND PLA.PLA_PROCESSO = '{processo}'
                                  AND ('{tipoDeProcesso}' IS NULL OR '{tipoDeProcesso}' = PRO.TIP_TIPO_PROCESSO)
                                ORDER BY PLA.PLA_STATUS_PROGRAMACAO ";

                OracleCommand cmd = new OracleCommand(query, conn);

                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByLocal(string regional)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT NVL(PLA_LOCAL, 'VAZIO') PLA_LOCAL
                                FROM PLANEJAMENTO
                                WHERE PLA_REGIONAL = '{regional}'
                                ORDER BY PLA_LOCAL ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByProducao(string regional,
                                                   string processo,
                                                   string tipoDeProcesso,
                                                   string estadoDoConjunto,
                                                   string conjunto,
                                                   string statusDaProgramacao,
                                                   bool localTronco,
                                                   bool localRamal)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query1 = $@" SELECT DISTINCT '{tipoDeProcesso}' TMP_TIPO_PROCESSO, ";

                var query2 = $@"                 PLA_RANKING_DEC_ATUAL_REGION,
                                                 PLA_RANKING_FEC_ATUAL_REGION,
                                                 PLA_RANKING_CLIENTE,
                                                 PLA_PROJETO, 
                                                 PLA_CONJUNTO,
                                                 PLA_ALIMENTADOR,
                                                 PLA_DISPOSITIVO,
                                                 PLA_ACAO,
                                                 PLA_UNIDADE,
                                                 PLA_QUANTIDADE_PENDENTE,
                                                 PLA_QTD_SERVICOS_DISPOSITIVO,
                                                 PLA_DISPOSITIVO_PENDENTE_PRO,
                                                 PLA_GAP_CONH_DEZ_ANEEL,
                                                 PLA_GAP_CONI_DEZ_ANEEL,
                                                 PLA_VALOR_TOTAL
                                                 FROM PLANEJAMENTO
                                                 WHERE PLA_REGIONAL = '{regional}'
                                                   AND PLA_PROCESSO = '{processo}'
                                                   AND('{conjunto}'           IS NULL OR '{conjunto}'             = PLA_CONJUNTO)
                                                   AND('{statusDaProgramacao}' IS NULL OR '{statusDaProgramacao}' = PLA_STATUS_PROGRAMACAO)";

                string query3;
                if (localTronco || localRamal)
                {
                    string tronco = "";
                    if (localTronco)
                    {
                        tronco = "TRONCO";
                    }

                    string ramal = "";
                    if (localRamal)
                    {
                        ramal = "RAMAL";
                    }

                    query3 = $@"                 AND UPPER(PLA_LOCAL) IN('{ramal}', '{tronco}')";
                }
                else
                {
                    query3 = "";
                }

                string query4;
                if (tipoDeProcesso == "DEC")
                {
                    query4 = $@"   AND PLA_RANKING_DEC_ATUAL_REGION IS NOT NULL
                                   ORDER BY LPAD(PLA_RANKING_DEC_ATUAL_REGION, 10), PLA_DISPOSITIVO ";
                }
                else if (tipoDeProcesso == "FEC")
                {
                    query4 = $@"   AND PLA_RANKING_FEC_ATUAL_REGION IS NOT NULL
                                   ORDER BY LPAD(PLA_RANKING_FEC_ATUAL_REGION, 10), PLA_DISPOSITIVO ";
                }
                else
                {
                    query4 = $@"   AND PLA_RANKING_CLIENTE IS NOT NULL
                                   ORDER BY LPAD(PLA_RANKING_CLIENTE, 10), PLA_DISPOSITIVO ";
                }

                var query = query1 + query2 + query3 + query4;

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectAll()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                //TODO: remover o limite de 50 dps
                var query = $@" SELECT *
                                FROM PLANEJAMENTO
                                WHERE ROWNUM <= 50 ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectById(string id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM PLANEJAMENTO
                                WHERE PLA_IDENTIFICADOR = '{id}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByProjeto(string dispositivo)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT PLA_PROJETO
                                FROM PLANEJAMENTO
                                WHERE PLA_DISPOSITIVO = '{dispositivo}'
                                ORDER BY PLA_PROJETO ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public List<Planejamento> SelectByDadosProjeto(string dispositivo, string projeto)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT DISTINCT *
                                FROM PLANEJAMENTO
                                WHERE PLA_DISPOSITIVO = '{dispositivo}'
                                  AND PLA_PROJETO = '{projeto}'
                                ORDER BY PLA_PROJETO ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public string SelectByFieldPorDispositivoProjeto(string dispositivo, string projeto, int valor)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                //1  - Processo
                //2  - OTCorrecao PLA_OTCORRECAO
                //3  - Conjunto 
                //4  - Alimentador
                //5  - QuantidadeClientes
                //6  - StatusProgramacao
                //7  - QuantidadeTotalInicial
                //8  - QuantidadePendente
                //9  - Ação
                //10 - Unidade
                //11 - Identificador do planejamento
                //12 - ImpactoCONH
                //13 - ImpactoCONI
                //14 - Regional
                var query = $@" SELECT DISTINCT CASE WHEN('{valor}' = 1)  THEN PLA.PLA_PROCESSO
                                                     WHEN('{valor}' = 2)  THEN null
                                                     WHEN('{valor}' = 3)  THEN PLA.PLA_CONJUNTO
                                                     WHEN('{valor}' = 4)  THEN PLA.PLA_ALIMENTADOR
                                                     WHEN('{valor}' = 5)  THEN PLA.PLA_TOTAL_CLIENTES
                                                     WHEN('{valor}' = 6)  THEN PLA.PLA_STATUS_PROGRAMACAO
                                                     WHEN('{valor}' = 7)  THEN PLA.PLA_QUANTIDADE_PLANO_ATUAL
                                                     WHEN('{valor}' = 8)  THEN TO_CHAR(NVL(PLA.PLA_QUANTIDADE_PENDENTE - PRO_QUANTIDADE_A_PROGRAMAR, 0))
                                                     WHEN('{valor}' = 9)  THEN PLA.PLA_ACAO
                                                     WHEN('{valor}' = 10) THEN PLA.PLA_UNIDADE
                                                     WHEN('{valor}' = 11) THEN TO_CHAR(PLA.PLA_IDENTIFICADOR)
                                                     WHEN('{valor}' = 12) THEN PLA.PLA_GAP_CONH_DEZ_ANEEL
                                                     WHEN('{valor}' = 13) THEN PLA.PLA_GAP_CONI_DEZ_ANEEL
                                                     WHEN('{valor}' = 14) THEN PLA.PLA_REGIONAL
                                                ELSE '' END INFORMACAO
                                FROM PLANEJAMENTO PLA
                                LEFT JOIN PROGRAMACAO PRO ON PRO.PRO_PLA_IDENTIFICADOR = PLA.PLA_IDENTIFICADOR
                                WHERE PLA_DISPOSITIVO = '{dispositivo}'
                                  AND PLA_PROJETO = '{projeto}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                //cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                //string informacao = (string)cmd.ExecuteScalar();
                var informacao = cmd.ExecuteScalar();

                return (informacao == null) ? string.Empty : informacao.ToString();
            }
        }

        #region GRÁFICOS
        public async Task<List<Planejamento>> ObterDadosDeDesvioPorRegional(string regional, string tipoGrafico)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = string.Empty;

                query = $@" SELECT DISTINCT PLA_CONJUNTO,
                                   TO_CHAR(PLA_DESVIO_DEC) PLA_DESVIO_DEC,
                                   TO_CHAR(PLA_DESVIO_FEC) PLA_DESVIO_FEC
                            FROM
                            (
                                SELECT DISTINCT PLA_CONJUNTO,
                                       SUM(PLA_DESVIO_DEC) PLA_DESVIO_DEC,
                                       SUM(PLA_DESVIO_FEC) PLA_DESVIO_FEC
                                FROM
                                (
                                    SELECT PLA_CONJUNTO, PLA_DESVIO_DEC, PLA_DESVIO_FEC
                                    FROM PLANEJAMENTO
                                    WHERE PLA_REGIONAL = '{regional}' ";


                query += $@" AND PLA_STATUS_EXECUCAO1 NOT IN('CONCLUÍDO')
                                    GROUP BY PLA_CONJUNTO, PLA_DESVIO_DEC, PLA_DESVIO_FEC
                                )
                                GROUP BY PLA_CONJUNTO
                            ) ";

                if (tipoGrafico == "DESVIO_CONH")
                {
                    query += $@" ORDER BY PLA_DESVIO_DEC DESC ";
                }

                if (tipoGrafico == "DESVIO_CONI")
                {
                    query += $@" ORDER BY PLA_DESVIO_FEC DESC ";
                }

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                await conn.OpenAsync();
                //await conn.Open();
                cmd.ExecuteScalar();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public async Task<List<Planejamento>> ObterDadosDeQualidadeManutencao(string regional, string limite, string local)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT   COUNT(PLA_LOCAL) AS PLA_QTDE_LOCAL ,
                                         PLA_LOCAL,
                                         PLA_ESTADO_CONJUNTO_DEC_LIMITE 
                                FROM     PLANEJAMENTO 
                                WHERE    UPPER(PLA_REGIONAL) = UPPER('" + regional + "') " +
                                " AND    UPPER(PLA_ESTADO_CONJUNTO_DEC_LIMITE) = UPPER('" + limite + "') " +
                                " AND    UPPER(PLA_LOCAL) = UPPER('" + local + "') " +
                                " AND    PLA_STATUS_EXECUCAO1 NOT IN ('CONCLUÍDO') " +
                                " HAVING COUNT(PLA_LOCAL) > 0 " +
                                " GROUP  BY PLA_LOCAL, PLA_ESTADO_CONJUNTO_DEC_LIMITE ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                await conn.OpenAsync();
                cmd.ExecuteScalar();

                return conn.Query<Planejamento>(query).ToList();
            }
        }

        public async Task<List<int>> ObterDadosObrasCliente(string regional, string tipo)
        {
            int maiorQueSessenta = 0;
            int trintaUm_sessenta = 0;
            int onze_trinta = 0;
            int zero_dez = 0;
            int foraDoPrazo = 0;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT TRUNC(TO_DATE(PLA_DATA_META_CONCLUSAO, 'DD/MM/YYYY' ) - TO_DATE(SYSDATE)) AS PLA_QTDE_DIAS_VENCIMENTO
                                FROM   PLANEJAMENTO 
                                WHERE  UPPER(PLA_REGIONAL) = UPPER('" + regional + "') " +
                                " AND UPPER(PLA_PROCESSO) = UPPER('" + tipo + "') ";

                //"-- AND PLA_STATUS_EXECUCAO1 NOT IN ('CONCLUÍDO') " +
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;
                await conn.OpenAsync();
                cmd.ExecuteScalar();

                List<int> listObrasClientes = new List<int>();

                foreach (var item in conn.Query<Planejamento>(query).ToList())
                {
                    if (item.PLA_QTDE_DIAS_VENCIMENTO > 60)
                    {
                        maiorQueSessenta++;
                    }

                    if (item.PLA_QTDE_DIAS_VENCIMENTO > 30 && item.PLA_QTDE_DIAS_VENCIMENTO <= 60)
                    {
                        trintaUm_sessenta++;
                    }

                    if (item.PLA_QTDE_DIAS_VENCIMENTO > 11 && item.PLA_QTDE_DIAS_VENCIMENTO <= 30)
                    {
                        onze_trinta++;
                    }

                    if (item.PLA_QTDE_DIAS_VENCIMENTO > 0 && item.PLA_QTDE_DIAS_VENCIMENTO <= 10)
                    {
                        zero_dez++;
                    }

                    if (item.PLA_QTDE_DIAS_VENCIMENTO < 0)
                    {
                        foraDoPrazo++;
                    }
                }

                listObrasClientes = new List<int>()
                {
                    maiorQueSessenta, trintaUm_sessenta, onze_trinta, zero_dez, foraDoPrazo
                };

                return listObrasClientes.ToList();
            }
        }
        #endregion
    }
}

