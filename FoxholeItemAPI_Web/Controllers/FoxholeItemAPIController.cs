using Microsoft.AspNetCore.Mvc;
using FoxholeItemAPI.Interfaces;
using FoxholeItemAPI.Repositories;
using System.Text.RegularExpressions;
using FoxholeItemAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoxholeItemAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class FoxholeItemAPIController : ControllerBase
    {
        IFoxholeItemAPIRepository _repo = new FoxholeItemAPIRepository();

        // GET: api/items
        [HttpGet]
        public IEnumerable<IItem> GetItems() => _repo.GetItems();

        // GET api/items/smallArms
        [HttpGet("{category}")]
        public IEnumerable<IItem> GetItemsInCategory(string category)
        {
            string categoryPascalCase = Regex.Replace(category, @"\b\w", m => m.Value.ToUpper()); ;
            Category categoryEnum;

            if (!Enum.TryParse(categoryPascalCase, out categoryEnum))
                throw new ApplicationException("Invalid category \"" + category + "\"");

            return _repo.GetItemsInCategory(categoryEnum);
        }
    }
}
