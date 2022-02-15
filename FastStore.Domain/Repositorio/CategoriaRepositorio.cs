using FastStore.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Repositorio
{
    public class CategoriaRepositorio : IRepositorio<Categoria>
    {
        private ProdutoContexto contexto;
        public CategoriaRepositorio(ProdutoContexto entidadesContexto)
        {
            this.contexto = entidadesContexto;
        }
       

        public IEnumerable<Categoria> GetTodos()
        {
            return contexto.Categorias.OrderBy(c => c.Nome);
        }

        public IEnumerable<Categoria> Get(int? id)
        {
            return contexto.Categorias.Where(c => c.CategoriaId == id);
        }

        
    }
}
