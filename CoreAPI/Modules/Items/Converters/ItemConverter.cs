using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items.Converters
{
    public class ItemConverter
    {
        public static ItemDto ConvertToItem(ItemPoco poco)
        {
            return new ItemDto
            {
                Nazwa = poco.Nazwa,
                Kolor = poco.Kolor,
                Cena = poco.Cena
            };
        }
    }
}
