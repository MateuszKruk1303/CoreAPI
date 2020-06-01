using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class GetItemQuery : IRequest<ItemDto>
    {
        public GetItemQuery(int itemId)
        {
            ItemId = itemId;
        }

        public int ItemId { get; set; }
    }
}
