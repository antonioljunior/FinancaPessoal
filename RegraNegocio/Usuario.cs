using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegraNegocio
{
    public class Usuario : ICrud<Entidades.Usuario>
    {
        AcessoDados.Usuario adUsuario = new AcessoDados.Usuario();

        public Entidades.Usuario ValidarLogin(Entidades.Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Login) ||
                string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Usuário e a senha devem ser informados");

            return adUsuario.ValidarLogin(usuario.Login, usuario.Senha);
        }

        public bool Salvar(Entidades.Usuario entidade)
        {
            return adUsuario.Salvar(entidade);
        }

        public bool Excluir(Entidades.Usuario entidade)
        {
            ValidarArgumento(entidade.Id);
            return adUsuario.Excluir(entidade);
        }

        public List<Entidades.Usuario> Selecionar(string where)
        {
            return adUsuario.Selecionar("");
        }

        public Entidades.Usuario ObterPorID(int? id)
        {
            ValidarArgumento(id);
            return adUsuario.Selecionar(string.
                Format("where usu_id = {0}", id))[0];
        }

        public List<Entidades.Usuario> ListarTodos()
        {
            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.Selecionar(string.Empty);
        }

        private void ValidarArgumento(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentException("O ID deve ser informado");
        }

    }
}
