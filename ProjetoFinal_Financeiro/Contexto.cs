using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_Financeiro
{
    public class Contexto
    {
        public static Entidades.Usuario Usuario 
        {
            get
            {
                return ((Entidades.Usuario)HttpContext.
                                            Current.
                                            Session["Usuario"]);
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }

        public static Entidades.Categoria Categoria
        {
            get
            {
                return ((Entidades.Categoria)HttpContext.Current.Cache["Categoria"]);
            }
            set
            {
                HttpContext.Current.Cache["Categoria"] = value;
            }
        }
    }
}