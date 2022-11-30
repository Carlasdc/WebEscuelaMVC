using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private AulaContext context= new AulaContext();
        // GET: Aula
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index",context.Aulas.ToList());

        }
        //GET: Aula/Create
        [HttpGet]
        public ActionResult Create()
        {
            Aula aula = new Aula();

            return View("Create", aula);
        }
        //POST: Aula
        [HttpPost]
        public ActionResult Create (Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", aula);
            }
        }
        //GET: aula
        public ActionResult Details(int id)
        {
            Aula aula =context.Aulas.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View("Details",aula);

        }

        // GET: /Aula/Edit  
        //enviar una view con un objeto producto 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Aula aula = context.Aulas.Find(id);
            return View("Edit",aula);
        }

        [HttpPost]
        public ActionResult Edit(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aula);
        }
        // GET: /Aula/Delete/id 
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();

            }

            return View("Delete", aula);

        }


        // POST: /Aula/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = context.Aulas.Find(id);
            if (aula != null)
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
            }

            return RedirectToAction("Index");

        }

    }
}