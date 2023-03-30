using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Repositories
{
    internal class FoxholeItemAPIRepository : AbstractFoxholeItemAPIRepository, IFoxholeItemAPIRepository
    {
        private string data = string.Empty;
        protected override void _LoadData()
        {

        }
        public List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public List<IItem> GetItemsInCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
