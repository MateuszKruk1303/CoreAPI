using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public interface IItemsRepository
    {
        IEnumerable<ItemDto> GetAllItems();
        ItemDto GetItem(int itemId);
        void AddItem(string nazwa, string kolor, int cena);
        void UpdateItem(int id, string nazwa, string kolor, int cena);
        void DeleteItem(int id);
    }
}
