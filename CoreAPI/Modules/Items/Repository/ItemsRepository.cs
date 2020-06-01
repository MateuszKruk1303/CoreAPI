using CoreAPI.Modules.Items.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            using (var db = itemContext)
            {
                items.AddRange(db.Item.ToList());
            }
            return items.Select(ItemConverter.ConvertToItem);
        }

        public ItemDto GetItem(int itemId)
        {
            var item = new ItemPoco();
            using (var db = itemContext)
            {
                item = db.Item.FirstOrDefault(n => n.Id == itemId);
            }
            return ItemConverter.ConvertToItem(item);
        }


        public void AddItem(string nazwa, string kolor, int cena)
        {
            var item = new ItemPoco()
            {
                Nazwa = nazwa,
                Kolor = kolor,
                Cena = cena
            };
            itemContext.Item.Add(item);
            itemContext.SaveChanges();
        }

        public async void UpdateItem(int id, string nazwa, string kolor, int cena)
        {
            var item = new ItemPoco()
            {
                Id = id == 0 ? itemContext.Item.AsNoTracking().FirstOrDefault(n => n.Nazwa == nazwa).Id : id,
                Nazwa = nazwa,
                Kolor = kolor,
                Cena = cena
            };
            itemContext.Item.Update(item);
            itemContext.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var item = itemContext.Item.FirstOrDefault(n => n.Id == id);
            // Alternatywa -> var item = itemContext.Item.Where(n => n.Id == id).FirstOrDefault();
            itemContext.Item.Remove(item);
            itemContext.SaveChanges();
        }
    }
}
