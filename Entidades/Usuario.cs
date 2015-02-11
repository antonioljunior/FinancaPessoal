using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> DataCriacao { get; set; }
        public string Cpf { get; set; }
    }
}
