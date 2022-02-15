using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using FastStore.Domain.Entidades;
using FastStore.Web.Models;

namespace FastStore.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private ProdutoContexto db = new ProdutoContexto();

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            //validar login do usuario
            if (!ModelState.IsValid)
            {
                return View();
            }

            using(ProdutoContexto dc = new ProdutoContexto())
            {
                var _usuario = dc.Usuarios.Where(u => u.Login.Equals(model.Login)).FirstOrDefault();
                if (!Crypto.VerifyHashedPassword(_usuario.Senha, model.Senha))
                {
                    _usuario = null;
                }
                if (_usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(_usuario.Login, model.LembrarMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("MenuAdmin", "Admin");
                    }
                }
            }
            ModelState.Remove("Senha");
            ModelState.AddModelError("", "Login Inválido");
            return View(model);
        }

        //logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Catalogo", "Produto");
        }

        //Registro do usuario

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(ProdutoContexto dc = new ProdutoContexto())
                {
                    var novoUsuario = new Usuario();
                    novoUsuario.Login = model.Nome;
                    novoUsuario.Senha = Crypto.HashPassword(novoUsuario.Senha);

                    dc.Usuarios.Add(novoUsuario);
                    dc.SaveChanges();
                    TempData["mensagem"] = string.Format("{0} : foi incluído com sucesso!", model.Nome);
                }
            }
            return View(model);
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuarioid,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //criptografar senha com hash
                usuario.Senha = Crypto.HashPassword(usuario.Senha);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuarioid,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
