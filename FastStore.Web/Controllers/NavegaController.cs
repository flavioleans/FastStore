using FastStore.Domain.Entidades;
using FastStore.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastStore.Web.Controllers
{
    public class NavegaController : Controller
    {
        private IRepositorio<Categoria> _RepositorioCategoria;
        public NavegaController()
        {
            _RepositorioCategoria = new CategoriaRepositorio(new ProdutoContexto());
        }

        public ActionResult Menu()
        {
            var categorias = _RepositorioCategoria.GetTodos();
            return PartialView(categorias);
        }
    }
}