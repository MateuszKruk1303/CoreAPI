using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class ItemPoco
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kolor { get; set; }
        public int Cena { get; set; }
    }
}
