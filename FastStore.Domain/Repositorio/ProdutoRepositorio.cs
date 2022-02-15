using FastStore.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace FastStore.Domain.Repositorio
{
    public class ProdutoRepositorio : IRepositorio<Produto>
    {
        private ProdutoContexto contexto;
        public ProdutoRepositorio(ProdutoContexto entidadesContexto)
        {
            this.contexto = entidadesContexto;
        }

      

        public IEnumerable<Produto> GetTodos()
        {
            return contexto.Produtos.ToList().OrderBy(p => p.Nome);
        }

        public IEnumerable<Produto> Get(int? id)
        {
            return contexto.Produtos.Where(p => p.CategoriaId == id).OrderBy(p => p.Nome);
        }
    }
}
