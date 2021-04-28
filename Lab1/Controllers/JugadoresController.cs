using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models.Data;

namespace Lab1.Controllers
{
    public class JugadoresController : Controller
    {
        // GET: JugadoresController
       
        public ActionResult Index()
        {
            return View(Singleton.Instance.JugadoresList);
        }

        // GET: JugadoresController/Details/5
        public ActionResult Details(int id)
        {
            var ViewJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
            return View(ViewJugadores);
        }

        // GET: JugadoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JugadoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newJugadores = new Models.Jugadores
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Name = collection["Name"],
                    Lastname = collection["Lastname"],
                    Club = collection["Club"],
                    Position = collection["Position"],
                    Salary = Convert.ToDouble(collection["Salary"]),
                    Compensation = Convert.ToDouble(collection["Compensation"])
                };
                Singleton.Instance.JugadoresList.Add(newJugadores);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JugadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var editJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
            return View(editJugadores);
        }

        // POST: JugadoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JugadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
            
            return View(deleteJugadores);
        }

        // POST: JugadoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var deleteJugadores = Singleton.Instance.JugadoresList.Find(x => x.Id == id);
                Singleton.Instance.JugadoresList.Remove(deleteJugadores);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
