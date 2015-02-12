using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Extensoes;

namespace AcessoDados
{
    public class Categoria : DAO<Entidades.Categoria>, ICrud<Entidades.Categoria>
    {
        public bool Salvar(Entidades.Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(Entidades.Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Categoria> Selecionar(string where)
        {
            try
            {
                conexao.Open();
                sql = @"SELECT CAT_ID, CAT_DESCRICAO FROM CATEGORIA " + where;

                comando = new SqlCommand(sql, conexao);
                dataAdapter = new SqlDataAdapter(comando);
                dataAdapter.Fill(dataTable);

                return MapearCategoria().ToList();
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

        private IEnumerable<Entidades.Categoria> MapearCategoria()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Entidades.Categoria()
                 {
                     Id = row["CAT_ID"].ToInt(),
                     Descricao = row["CAT_DESCRICAO"].ToString()
                 };
            }
        }

    }
}
