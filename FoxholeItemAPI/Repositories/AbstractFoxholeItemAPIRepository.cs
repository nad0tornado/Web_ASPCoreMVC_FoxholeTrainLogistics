using FoxholeItemAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Repositories
{
    internal abstract class AbstractFoxholeItemAPIRepository
    {
        protected abstract void _LoadData();
    }
}
