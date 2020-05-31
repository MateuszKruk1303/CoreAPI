using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> option) : base(option)
        {

        }

        public DbSet<ItemPoco> Item { get; set; }
    }
}
