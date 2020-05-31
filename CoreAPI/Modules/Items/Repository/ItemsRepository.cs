using CoreAPI.Modules.Items.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ItemContext itemContext;

        public ItemsRepository(ItemContext itemContext)
        {
            this.itemContext = itemContext;
        }

        public IEnumerable<ItemDto> GetAllItems()
        {
            var items = new List<ItemPoco>();
            var test = itemContext.Item.ToList();
            using (var db = itemContext)
            {
                items.AddRange(db.Item.ToList());
            }
            return items.Select(ItemConverter.ConvertToItem);
        }
    }
}
