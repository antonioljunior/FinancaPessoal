using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Extensoes;
using Interfaces;

namespace AcessoDados
{
    public class Usuario : DAO<Entidades.Usuario>, ICrud<Entidades.Usuario>
    {
        public Entidades.Usuario ValidarLogin(string login, string senha)
        {
            try
            {
                base.conexao.Open();
                sql = @"SELECT USU_ID, USU_NOME, USU_LOGIN, USU_SENHA,
                               USU_EMAIL, USU_DT_CRIACAO, USU_CPF
                        FROM USUARIO
                        WHERE USU_LOGIN = @LOGIN
                        AND USU_SENHA = @SENHA";

                base.comando = new SqlCommand(sql, base.conexao);
                base.comando.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@LOGIN",
                    Value = login
                });
                base.comando.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@SENHA",
                    Value = senha
                });
                base.dataAdapter = new SqlDataAdapter(base.comando);
                base.dataAdapter.Fill(dataTable);
                var retorno = new Entidades.Usuario();

                if (dataTable.Rows.Count == 1)
                {
                    retorno.Id = dataTable.Rows[0]["USU_ID"].ToInt();
                    retorno.Nome = dataTable.Rows[0]["USU_NOME"].ToString();
                    retorno.Login = dataTable.Rows[0]["USU_LOGIN"].ToString();
                    retorno.Senha = dataTable.Rows[0]["USU_SENHA"].ToString();
                    retorno.Email = dataTable.Rows[0]["USU_EMAIL"].ToString();
                    retorno.DataCriacao = dataTable.Rows[0]["USU_DT_CRIACAO"].ToDateTime();
                    retorno.Cpf = dataTable.Rows[0]["USU_CPF"].ToString();
                }

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                base.conexao.Close();
            }
        }
        
        public bool Salvar(Entidades.Usuario entidade)
        {
            try
            {
                base.conexao.Open();

                comando = new SqlCommand(sql, conexao);
                AdicionarParametros(entidade);

                if (entidade.Id > 0)
                    AtualizarUsuario(entidade, sql);
                else
                    InserirUsuario(entidade, sql);

                return comando.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                base.conexao.Close();
            }
        }

        public bool Excluir(Entidades.Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Usuario> Selecionar(string where)
        {
            throw new NotImplementedException();
        }
        
        #region Privados

        private void AdicionarParametros(Entidades.Usuario entidade)
        {
            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@NOME",
                Value = entidade.Nome
            });
            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@LOGIN",
                Value = entidade.Login
            });
            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@SENHA",
                Value = entidade.Senha
            });
            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@EMAIL",
                Value = entidade.Email
            });
            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@CPF",
                Value = entidade.Cpf
            });
        }

        private void InserirUsuario(Entidades.Usuario entidade, string sql)
        {
            sql = @"INSERT INTO [Financa_Pessoal].[dbo].[USUARIO]
                                       ([USU_NOME]
                                       ,[USU_LOGIN]
                                       ,[USU_SENHA]
                                       ,[USU_EMAIL]
                                       ,[USU_DT_CRIACAO]
                                       ,[USU_CPF])
                                 VALUES
                                       (@NOME
                                       ,@LOGIN
                                       ,@SENHA
                                       ,@EMAIL
                                       ,@DT_CRIACAO
                                       ,@CPF)";

            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DT_CRIACAO",
                Value = entidade.DataCriacao
            });
        }

        private void AtualizarUsuario(Entidades.Usuario entidade, string sql)
        {
            sql = @"UPDATE [Financa_Pessoal].[dbo].[USUARIO]
                                         SET [USU_NOME] = @NOME
                                            ,[USU_LOGIN] = @LOGIN
                                            ,[USU_SENHA] = @SENHA
                                            ,[USU_EMAIL] = @EMAIL
                                            ,[USU_CPF] = @CPF
                                         WHERE USU_ID = @ID";

            comando.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ID",
                Value = entidade.Id
            });
        }

        #endregion
    }
}
