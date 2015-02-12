using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal_Financeiro
{
    public partial class ListaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegraNegocio.Usuario u = new RegraNegocio.Usuario();
            gvUsuario.DataSource = u.ListarTodos();
            gvUsuario.DataBind();
        }
    }
}