using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers
{
    public class EntityApiController : Controller
    {
        // GET: EntityApiController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EntityApiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntityApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityApiController/Create
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

        // GET: EntityApiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntityApiController/Edit/5
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

        // GET: EntityApiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntityApiController/Delete/5
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
