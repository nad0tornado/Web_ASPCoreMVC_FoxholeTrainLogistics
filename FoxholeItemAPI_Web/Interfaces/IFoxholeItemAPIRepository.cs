using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxholeItemAPI.Utils;

namespace FoxholeItemAPI.Interfaces
{
    public interface IFoxholeItemAPIRepository
    {
        public IEnumerable<IItem> GetItems();
        public IEnumerable<IItem> GetItemsInCategory(Category category);
    }
}
