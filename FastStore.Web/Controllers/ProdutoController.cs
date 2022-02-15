using FastStore.Domain.Entidades;
using FastStore.Domain.Repositorio;
using PagedList;
using System.Web.Mvc;

namespace FastStore.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IRepositorio<Produto> _RepositorioProduto;
        public ProdutoController()
        {
            _RepositorioProduto = new ProdutoRepositorio(new ProdutoContexto());
        }
        // GET: Produto
        public ViewResult Catalogo(int? pag, int? cat)
        {
            if (cat == null)
            {
                return View(_RepositorioProduto.GetTodos().ToPagedList(pag ?? 1, 2));
            }
            else
            {
                return View(_RepositorioProduto.Get(cat).ToPagedList(pag ?? 1, 2));
            }
        }
    }
}