using Microsoft.AspNetCore.Mvc;

namespace FoxholeTrainLogistics.Controllers
{
    public class ShipmentCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
