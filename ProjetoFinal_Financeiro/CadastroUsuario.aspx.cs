using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensoes;

namespace ProjetoFinal_Financeiro
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            RegraNegocio.Usuario u = new RegraNegocio.Usuario();
            Entidades.Usuario entidade = new Entidades.Usuario()
                {
                    Nome = txtNome.Text,
                    Senha = txtSenha.Text,
                    Login = txtSenha.Text,
                    Email = txtEmail.Text,
                    Cpf = txtCPF.Text.RemoverMascara(),
                    DataCriacao = DateTime.Now
                };
            if (u.Salvar(entidade))
            {
                LimparCampos();
            }
            else
            {

            }
        }

        private void LimparCampos()
        {
            txtNome.Text =
             txtSenha.Text =
             txtSenha.Text =
             txtEmail.Text =
            txtCPF.Text = string.Empty;
        }
    }
}