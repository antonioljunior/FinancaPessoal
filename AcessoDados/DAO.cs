using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AcessoDados
{
    public abstract class DAO<T> where T : Entidades.EntidadeBase
    {
        protected SqlConnection conexao = new SqlConnection(
                                             ConfigurationManager.
                                             ConnectionStrings["SqlServer"].
                                             ConnectionString);
        protected SqlCommand comando;
        protected SqlDataAdapter dataAdapter;
        protected DataTable dataTable = new DataTable();
                
        public abstract bool Salvar(T entidade);
        public abstract bool Excluir(T entidade);
        public abstract List<T> Selecionar(string where);
    }
}
