﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastStore.Domain.Entidades;

namespace FastStore.Web.Controllers
{
    public class UsuarioPermissaoController : Controller
    {
        private ProdutoContexto db = new ProdutoContexto();

        // GET: UsuarioPermissao
        public ActionResult Index()
        {
            var usuarioPermissoes = db.UsuarioPermissoes.Include(u => u.Permissao).Include(u => u.Usuario);
            return View(usuarioPermissoes.ToList());
        }

        // GET: UsuarioPermissao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPermissao usuarioPermissao = db.UsuarioPermissoes.Find(id);
            if (usuarioPermissao == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPermissao);
        }

        // GET: UsuarioPermissao/Create
        public ActionResult Create()
        {
            ViewBag.PermissaoId = new SelectList(db.Permissoes, "PermissaoId", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Usuarioid", "Login");
            return View();
        }

        // POST: UsuarioPermissao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissaoUsuarioId,PermissaoId,UsuarioId")] UsuarioPermissao usuarioPermissao)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioPermissoes.Add(usuarioPermissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermissaoId = new SelectList(db.Permissoes, "PermissaoId", "Nome", usuarioPermissao.PermissaoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Usuarioid", "Login", usuarioPermissao.UsuarioId);
            return View(usuarioPermissao);
        }

        // GET: UsuarioPermissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPermissao usuarioPermissao = db.UsuarioPermissoes.Find(id);
            if (usuarioPermissao == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissaoId = new SelectList(db.Permissoes, "PermissaoId", "Nome", usuarioPermissao.PermissaoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Usuarioid", "Login", usuarioPermissao.UsuarioId);
            return View(usuarioPermissao);
        }

        // POST: UsuarioPermissao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissaoUsuarioId,PermissaoId,UsuarioId")] UsuarioPermissao usuarioPermissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioPermissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissaoId = new SelectList(db.Permissoes, "PermissaoId", "Nome", usuarioPermissao.PermissaoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Usuarioid", "Login", usuarioPermissao.UsuarioId);
            return View(usuarioPermissao);
        }

        // GET: UsuarioPermissao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPermissao usuarioPermissao = db.UsuarioPermissoes.Find(id);
            if (usuarioPermissao == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPermissao);
        }

        // POST: UsuarioPermissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioPermissao usuarioPermissao = db.UsuarioPermissoes.Find(id);
            db.UsuarioPermissoes.Remove(usuarioPermissao);
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
