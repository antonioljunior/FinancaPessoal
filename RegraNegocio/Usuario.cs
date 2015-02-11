using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegraNegocio
{
    public class Usuario
    {
        public Entidades.Usuario ValidarLogin(Entidades.Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Login) ||
                string.IsNullOrWhiteSpace(usuario.Senha))
                throw new Exception("Usuário e a senha devem ser informados");

            AcessoDados.Usuario u = new AcessoDados.Usuario();
            return u.ValidarLogin(usuario.Login, usuario.Senha);
        }
    }
}
