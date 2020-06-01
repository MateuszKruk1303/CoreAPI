using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class GetItemsListQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}
