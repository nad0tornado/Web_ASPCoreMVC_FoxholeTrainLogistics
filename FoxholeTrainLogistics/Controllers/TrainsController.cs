using FoxholeTrainLogistics.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoxholeTrainLogistics.Models;

namespace FoxholeTrainLogistics.Controllers
{
    public class TrainsController : Controller
    {
        private readonly ITrainsDbContext _dbContext;

        public TrainsController(ITrainsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: TrainsController
        public ActionResult Index()
        {
            var trainsViewModel = new TrainsViewModel()
            {
                Trains = _dbContext.Trains.Select(t => new TrainViewModel(t,false)).ToList()
            };

            return View(trainsViewModel);
        }

        // GET: TrainsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainsController/Create
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

        // GET: TrainsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainsController/Edit/5
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

        // GET: TrainsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrainsController/Delete/5
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
