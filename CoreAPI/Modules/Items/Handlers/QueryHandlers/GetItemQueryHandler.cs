using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
    {
        private readonly IItemsRepository itemsRepository;

        public GetItemQueryHandler(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            return itemsRepository.GetItem(request.ItemId);
        }

    }
}
