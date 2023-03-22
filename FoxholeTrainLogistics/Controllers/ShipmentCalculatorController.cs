using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

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
