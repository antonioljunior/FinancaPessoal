using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface ICrud<T>
    {
        bool Salvar(T entidade);
        bool Excluir(T entidade);
        List<T> Selecionar(string where);
    }
}
