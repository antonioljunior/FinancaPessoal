using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProjetoFinal_Financeiro
{
    public class Mensagem
    {
        public static void Alerta(Page pagina, string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(pagina,
                    pagina.GetType(),
                    Guid.NewGuid().ToString(),
                    "alert('"+ mensagem + "');",
                    true);
        }
    }
}