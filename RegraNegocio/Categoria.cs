using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegraNegocio
{
    public class Categoria : ICrud<Entidades.Categoria>
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
            throw new NotImplementedException();
        }

        public List<Entidades.Categoria> ListarTodos()
        {
            AcessoDados.Categoria c = new AcessoDados.Categoria();
            return c.Selecionar(string.Empty);
        }
    }
}
