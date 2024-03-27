using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace AtlantidaAppCuentaTarjeta.Controllers
{
    public class EstadoCuentaController : Controller
    {
        // GET: EstadoCuentaController
        public ActionResult EstadoCuenta()
        {
            return View();
        }

        //Indice donde estan las tarjetas
        public ActionResult Index()
        {
            return View();
        }

        //Registrar compra
        public ActionResult RegCompra()
        {
            return View();
        }

        public ActionResult RegPago()
        {
            return View();
        }



        // GET: EstadoCuentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadoCuentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCuentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EstadoCuentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoCuentaController/Edit/5
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

        // GET: EstadoCuentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoCuentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
