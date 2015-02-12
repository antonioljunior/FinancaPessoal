using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensoes;

namespace ProjetoFinal_Financeiro
{
    public partial class ListaUsuario : System.Web.UI.Page
    {
        RegraNegocio.Usuario rnUsuario = new RegraNegocio.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGrid();
                if (Request.QueryString["Status"] != null)
                    Mensagem.Alerta(this, "Usuário cadastrado com sucesso.");
            }
        }

        private void PopularGrid()
        {
            gvUsuario.DataSource = rnUsuario.ListarTodos();
            gvUsuario.DataBind();
        }

        protected void gvUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Entidades.Usuario u = new Entidades.Usuario();
                u.Id = e.Keys[0].ToInt();
                rnUsuario.Excluir(u);
                PopularGrid();
                Mensagem.Alerta(this, "Usuário excluído com sucesso.");
            }
            catch (Exception ex)
            {
                Mensagem.Alerta(this, ex.Message);
            }
        }

        protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
                Response.Redirect(URL.CADASTRO_USUARIO + "?Codigo=" + e.CommandArgument);
        }

        protected void gvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("btnEditar")).CommandArgument =
                    ((Entidades.Usuario)e.Row.DataItem).Id.ToString();
            }
        }
    }
}