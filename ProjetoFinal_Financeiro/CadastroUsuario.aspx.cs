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
        RegraNegocio.Usuario rnUsuario = new RegraNegocio.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Codigo"] != null)
            {
                Entidades.Usuario u = rnUsuario.Selecionar();
                txtNome.Text = u.Nome;
                txtLogin.Text = u.Login;
                txtSenha.Text = u.Senha;
                txtCPF.Text = u.Cpf;
                txtEmail.Text = u.Email;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Entidades.Usuario entidade = new Entidades.Usuario()
                {
                    Nome = txtNome.Text,
                    Senha = txtSenha.Text,
                    Login = txtSenha.Text,
                    Email = txtEmail.Text,
                    Cpf = txtCPF.Text.RemoverMascara(),
                    DataCriacao = DateTime.Now
                };
            if (rnUsuario.Salvar(entidade))
            {
                LimparCampos();
            }
            else
            {
                Mensagem.Alerta(this, "Ocorreu um erro ao salvar o Usuário");
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