using Dapper;
using Oracle.ManagedDataAccess.Client;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL
{
    public class UsuarioRepository
    {
        private string connectionString;

        public UsuarioRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoPIP"].ConnectionString;
        }

        public List<Usuario> SelectAll()
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM USUARIO";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();
                //cmd.ExecuteNonQuery();

                return conn.Query<Usuario>(query).ToList();
            }
        }

        public Usuario SelectById(long id)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM USUARIO
                                WHERE USU_IDENTIFICADOR = '{id}' ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();

                return conn.Query<Usuario>(query).FirstOrDefault();
            }
        }

        public Usuario SelectByLogin(string login)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM USUARIO
                                INNER JOIN PERFIL_USUARIO ON USU_IDENTIFICADOR = PRU_USU_IDENTIFICADOR
                                INNER JOIN PERFIL ON PRU_PRF_IDENTIFICADOR = PRF_IDENTIFICADOR
                                WHERE USU_LOGIN = '{login}' 
                                ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();

                return conn.Query
                    (query, (Usuario u, Perfil p) =>
                    {
                        u.Perfis.Add(p);
                        return u;
                    },
                    splitOn: "PRF_IDENTIFICADOR")
                    //.ToList();    
                    .FirstOrDefault();
            }
        }

        public Usuario SelectByLoginSenha(string login, string senha)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                var query = $@" SELECT *
                                FROM USUARIO
                                INNER JOIN PERFIL_USUARIO ON USU_IDENTIFICADOR = PRU_USU_IDENTIFICADOR
                                INNER JOIN PERFIL ON PRU_PRF_IDENTIFICADOR = PRF_IDENTIFICADOR
                                WHERE USU_LOGIN = '{login}' AND USU_SENHA = '{senha}'
                                ";

                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.BindByName = true;

                conn.Open();
                cmd.ExecuteScalar();

                return conn.Query
                    (query, (Usuario u, Perfil p) =>
                    {
                        u.Perfis.Add(p);
                        return u;
                    },
                    splitOn: "PRF_IDENTIFICADOR")
                    //.ToList();    
                    .FirstOrDefault();
            }
        }
    }
}
