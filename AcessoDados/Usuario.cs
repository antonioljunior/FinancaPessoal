using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Extensoes;

namespace AcessoDados
{
    public class Usuario : DAO<Entidades.Usuario>
    {
        public Entidades.Usuario ValidarLogin(string login, string senha)
        {
            try
            {
                base.conexao.Open();
                string sql = @"SELECT USU_ID, USU_NOME, USU_LOGIN, USU_SENHA,
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

        public override bool Salvar(Entidades.Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(Entidades.Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public override List<Entidades.Usuario> Selecionar(string where)
        {
            throw new NotImplementedException();
        }
    }
}
