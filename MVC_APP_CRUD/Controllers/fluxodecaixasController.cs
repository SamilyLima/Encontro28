using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_APP_CRUD.Models;

namespace MVC_APP_CRUD.Controllers
{
    public class fluxodecaixasController : Controller
    {
        private fluxo_caixaEntities db = new fluxo_caixaEntities();

        // GET: fluxodecaixas
        public ActionResult Index()
        {
            var fluxodecaixas = db.fluxodecaixas.Include(f => f.cliente).Include(f => f.despesa).Include(f => f.fornecedor).Include(f => f.produto).Include(f => f.tipodelancamento);
            return View(fluxodecaixas.ToList());
        }

        // GET: fluxodecaixas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fluxodecaixa fluxodecaixa = db.fluxodecaixas.Find(id);
            if (fluxodecaixa == null)
            {
                return HttpNotFound();
            }
            return View(fluxodecaixa);
        }

        // GET: fluxodecaixas/Create
        public ActionResult Create()
        {
            ViewBag.clienteid = new SelectList(db.clientes, "clienteid", "nome");
            ViewBag.despesaid = new SelectList(db.despesas, "despesaid", "descrição");
            ViewBag.fornecedorid = new SelectList(db.fornecedors, "fornecedorid", "nome");
            ViewBag.produtoid = new SelectList(db.produtoes, "produtoid", "descrição");
            ViewBag.tipodelancamentoid = new SelectList(db.tipodelancamentoes, "tipodelancamentoid", "nomedotipo");
            return View();
        }

        // POST: fluxodecaixas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fluxodecaixaid,data,qtd,valorproduto,tipodemovimento,despesaid,fornecedorid,produtoid,clienteid,tipodelancamentoid")] fluxodecaixa fluxodecaixa)
        {
            if (ModelState.IsValid)
            {
                db.fluxodecaixas.Add(fluxodecaixa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clienteid = new SelectList(db.clientes, "clienteid", "nome", fluxodecaixa.clienteid);
            ViewBag.despesaid = new SelectList(db.despesas, "despesaid", "descrição", fluxodecaixa.despesaid);
            ViewBag.fornecedorid = new SelectList(db.fornecedors, "fornecedorid", "nome", fluxodecaixa.fornecedorid);
            ViewBag.produtoid = new SelectList(db.produtoes, "produtoid", "descrição", fluxodecaixa.produtoid);
            ViewBag.tipodelancamentoid = new SelectList(db.tipodelancamentoes, "tipodelancamentoid", "nomedotipo", fluxodecaixa.tipodelancamentoid);
            return View(fluxodecaixa);
        }

        // GET: fluxodecaixas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fluxodecaixa fluxodecaixa = db.fluxodecaixas.Find(id);
            if (fluxodecaixa == null)
            {
                return HttpNotFound();
            }
            ViewBag.clienteid = new SelectList(db.clientes, "clienteid", "nome", fluxodecaixa.clienteid);
            ViewBag.despesaid = new SelectList(db.despesas, "despesaid", "descrição", fluxodecaixa.despesaid);
            ViewBag.fornecedorid = new SelectList(db.fornecedors, "fornecedorid", "nome", fluxodecaixa.fornecedorid);
            ViewBag.produtoid = new SelectList(db.produtoes, "produtoid", "descrição", fluxodecaixa.produtoid);
            ViewBag.tipodelancamentoid = new SelectList(db.tipodelancamentoes, "tipodelancamentoid", "nomedotipo", fluxodecaixa.tipodelancamentoid);
            return View(fluxodecaixa);
        }

        // POST: fluxodecaixas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fluxodecaixaid,data,qtd,valorproduto,tipodemovimento,despesaid,fornecedorid,produtoid,clienteid,tipodelancamentoid")] fluxodecaixa fluxodecaixa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fluxodecaixa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clienteid = new SelectList(db.clientes, "clienteid", "nome", fluxodecaixa.clienteid);
            ViewBag.despesaid = new SelectList(db.despesas, "despesaid", "descrição", fluxodecaixa.despesaid);
            ViewBag.fornecedorid = new SelectList(db.fornecedors, "fornecedorid", "nome", fluxodecaixa.fornecedorid);
            ViewBag.produtoid = new SelectList(db.produtoes, "produtoid", "descrição", fluxodecaixa.produtoid);
            ViewBag.tipodelancamentoid = new SelectList(db.tipodelancamentoes, "tipodelancamentoid", "nomedotipo", fluxodecaixa.tipodelancamentoid);
            return View(fluxodecaixa);
        }

        // GET: fluxodecaixas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fluxodecaixa fluxodecaixa = db.fluxodecaixas.Find(id);
            if (fluxodecaixa == null)
            {
                return HttpNotFound();
            }
            return View(fluxodecaixa);
        }

        // POST: fluxodecaixas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fluxodecaixa fluxodecaixa = db.fluxodecaixas.Find(id);
            db.fluxodecaixas.Remove(fluxodecaixa);
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
