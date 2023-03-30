using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeItemAPI.Models
{
    internal class FoxholeItemAPIItem
    {
        public int DisplayId { get; set; }
        public string[] Faction { get; set; } = Array.Empty<string>();
        public string ImgName { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemDesc { get; set; } = string.Empty;
        public string ItemCategory { get; set; } = string.Empty;
        public string ItemClass { get; set; } = string.Empty;
        public string AmmoUsed { get; set; } = string.Empty;
        public int NumberProduced { get; set; }
        public bool IsTeched { get; set; }
        public bool IsMpfCraftable { get; set; }
        public string[] CraftLocation { get; set; } = Array.Empty<string>();
        public Dictionary<string, int> Cost { get; set; } = new Dictionary<string, int>();
    }
}
