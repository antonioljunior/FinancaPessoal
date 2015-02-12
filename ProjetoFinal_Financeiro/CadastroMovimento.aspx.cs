using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal_Financeiro
{
    public partial class CadastroMovimento : System.Web.UI.Page
    {
        RegraNegocio.Categoria c = new RegraNegocio.Categoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = c.ListarTodos();
                ddlCategoria.DataValueField = "ID";
                ddlCategoria.DataTextField = "Descricao";
                ddlCategoria.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategoria.DataSource = c.ListarTodos();
            ddlSubCategoria.DataValueField = "ID";
            ddlSubCategoria.DataTextField = "Descricao";
            ddlSubCategoria.DataBind();
        }
    }
}