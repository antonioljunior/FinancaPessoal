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
            if (!IsPostBack)
                CarregarUsuario();
        }

        private void CarregarUsuario()
        {
            if (Request.QueryString["Codigo"] != null)
            {
                int? id = Request.QueryString["Codigo"].ToInt();
                Entidades.Usuario u = rnUsuario.ObterPorID(id);
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

            if (Request.QueryString["Codigo"] != null)
                entidade.Id = Request.QueryString["Codigo"].ToInt();

            if (rnUsuario.Salvar(entidade))
            {
                Response.Redirect(URL.LISTA_USUARIO + "?Status=OK");
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