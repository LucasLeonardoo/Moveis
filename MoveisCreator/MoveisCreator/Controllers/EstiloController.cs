using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoveisCreator.DAO;
using MoveisCreator.Models;
using MovelCreator.Models;

namespace MoveisCreator.Controllers
{
    public class EstiloController : Controller
    {
        private Entities db = Singleton.Instance.Entities;

        // GET: Estilo
        public ActionResult Index()
        {
            return View(db.Estilos.ToList());
        }

        // GET: Estilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // GET: Estilo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estilo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeDoEstilo")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Estilos.Add(estilo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estilo);
        }

        // GET: Estilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeDoEstilo")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estilo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);
        }

        // GET: Estilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = db.Estilos.Find(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estilo estilo = db.Estilos.Find(id);
            db.Estilos.Remove(estilo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
