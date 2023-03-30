using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Interfaces
{
    internal interface IFoxholeItemAPIRepository
    {
        public List<IItem> GetItems();
        public List<IItem> GetItemsInCategory(Category category);
    }
}
