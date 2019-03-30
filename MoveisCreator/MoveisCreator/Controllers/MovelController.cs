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
    public class MovelController : Controller
    {
        private Entities db = new Entities();

        // GET: Movel
        public ActionResult Index()
        {
            return View(db.Moveis.ToList());
        }

        // GET: Movel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Moveis.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // GET: Movel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeDoMovel")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Moveis.Add(movel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movel);
        }

        // GET: Movel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Moveis.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Movel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeDoMovel")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movel);
        }

        // GET: Movel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Moveis.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Movel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movel movel = db.Moveis.Find(id);
            db.Moveis.Remove(movel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Criar Movel com Estilo
        public ActionResult CriarMovel()
        {
            ViewBag.MovelId = new SelectList(db.Moveis, "MovelId", "NomeDoMovel");
            ViewBag.EstiloId = new SelectList(db.Estilos, "EstiloId", "NomeDoEstilo");

            if (db.Moveis.ToList().Count == 0)
            {
                return RedirectToAction("Index", "Movel");
            }
            else if (db.Estilos.ToList().Count == 0)
            {
                return RedirectToAction("Index", "Estilo");
            }
            else
            {
                return View();
            }
        }

        // Criar Movel Com Estilo ..
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarMovel([Bind(Include = "MovelId, CursoId")] Movel movel, Estilo estilo)
        {
            Movel movelAux = db.Moveis.Find(movel.MovelId);
            Estilo estiloAux = db.Estilos.Find(estilo.EstiloId);

            
            CriarMovel novoMovel = new CriarMovel();
            novoMovel.Movel = movelAux;
            novoMovel.Estilo = estiloAux;
            if (CriarMovelDAO.CriandoMovel(novoMovel))
            {
                return RedirectToAction("Index", "Movel");
            }


            

            return RedirectToAction("Index", "Home");
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
