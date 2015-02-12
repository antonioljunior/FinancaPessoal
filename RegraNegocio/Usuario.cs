using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegraNegocio
{
    public class Usuario : ICrud<Entidades.Usuario>
    {
        public Entidades.Usuario ValidarLogin(Entidades.Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Login) ||
                string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Usuário e a senha devem ser informados");

            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.ValidarLogin(usuario.Login, usuario.Senha);
        }

        public bool Salvar(Entidades.Usuario entidade)
        {
           //Validações
            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.Salvar(entidade);
        }

        public bool Excluir(Entidades.Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Usuario> Selecionar(string where)
        {
            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.Selecionar("");
        }

        public List<Entidades.Usuario> ListarTodos()
        {
            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.Selecionar(string.Empty);
        }
    }
}
