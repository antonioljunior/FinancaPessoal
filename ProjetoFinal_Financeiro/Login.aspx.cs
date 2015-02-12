using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RN = RegraNegocio;

namespace ProjetoFinal_Financeiro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            var u = new RN.Usuario();
            var usuario = new Entidades.Usuario()
            {
                Login = txtUsuario.Text,
                Senha = txtSenha.Text
            };
            var retornoUsuario = u.ValidarLogin(usuario);
            if (retornoUsuario.Id > 0)
            {
                Contexto.Usuario = retornoUsuario;
                Response.Redirect(URL.INDEX);
            }
            else
                Mensagem.Alerta(this, "Login ou senha incorretos");
        }
    }
}