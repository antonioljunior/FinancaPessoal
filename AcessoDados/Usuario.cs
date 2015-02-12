using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Extensoes;
using Interfaces;
using System.Data;

namespace AcessoDados
{
    public class Usuario : DAO<Entidades.Usuario>, ICrud<Entidades.Usuario>
    {
        public Entidades.Usuario ValidarLogin(string login, string senha)
        {
            try
            {
                string where = string.Format(@"WHERE USU_LOGIN = '{0}'
                                               AND USU_SENHA = '{1}'", login, senha);

                var retorno = Selecionar(where);
                if (retorno.Count == 1)
                    return retorno[0];

                return new Entidades.Usuario();
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
                conexao.Open();

                comando = new SqlCommand();
                AdicionarParametros(entidade);

                if (entidade.Id > 0)
                    AtualizarUsuario(entidade);
                else
                    InserirUsuario(entidade);

                comando.Connection = conexao;
                comando.CommandText = sql;
                return comando.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.conexao.Close();
            }
        }

        public bool Excluir(Entidades.Usuario entidade)
        {
            try
            {
                conexao.Open();
                sql = @"DELETE USUARIO WHERE USU_ID = @ID";
                comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = entidade.Id
                });
                
                return comando.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Entidades.Usuario> Selecionar(string where)
        {
            try
            {
                conexao.Open();
                sql = @"SELECT [USU_ID]
                              ,[USU_NOME]
                              ,[USU_LOGIN]
                              ,[USU_SENHA]
                              ,[USU_EMAIL]
                              ,[USU_DT_CRIACAO]
                              ,[USU_CPF]
                          FROM [Financa_Pessoal].[dbo].[USUARIO]
                        " + where;

                comando = new SqlCommand(sql, conexao);
                dataAdapter = new SqlDataAdapter(comando);
                dataAdapter.Fill(dataTable);
                return MapearUsuario().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        #region Privados

        private IEnumerable<Entidades.Usuario> MapearUsuario()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Entidades.Usuario()
                 {
                     Id = row["USU_ID"].ToInt(),
                     Nome = row["USU_NOME"].ToString(),
                     Login = row["USU_LOGIN"].ToString(),
                     Senha = row["USU_SENHA"].ToString(),
                     Email = row["USU_EMAIL"].ToString(),
                     DataCriacao = row["USU_DT_CRIACAO"].ToDateTime(),
                     Cpf = row["USU_CPF"].ToString()
                 };
            }
        }

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

        private void InserirUsuario(Entidades.Usuario entidade)
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

        private void AtualizarUsuario(Entidades.Usuario entidade)
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
