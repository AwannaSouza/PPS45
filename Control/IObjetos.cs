using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public interface IObjetos<TEntity> where TEntity : class
    {
        bool Adicionar();
        bool Salvar();
        bool Desativar();
        List<TEntity> Listar(string connString);
    }
}
