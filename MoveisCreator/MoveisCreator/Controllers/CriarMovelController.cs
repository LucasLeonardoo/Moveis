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
    public class CriarMovelController : Controller
    {
        private Entities db = Singleton.Instance.Entities;

        // GET: CriarMovel
        public ActionResult Index()
        {
            var criarMoveis = db.CriarMoveis.Include(c => c.Estilo).Include(c => c.Movel);
            return View(criarMoveis.ToList());
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
                return RedirectToAction("Index", "CriarMovel");
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: CriarMovel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriarMovel criarMovel = db.CriarMoveis.Find(id);
            if (criarMovel == null)
            {
                return HttpNotFound();
            }
            return View(criarMovel);
        }

        // POST: CriarMovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CriarMovel criarMovel = db.CriarMoveis.Find(id);
            db.CriarMoveis.Remove(criarMovel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
