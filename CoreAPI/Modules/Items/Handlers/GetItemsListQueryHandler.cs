using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, IEnumerable<ItemDto>>
    {
        private readonly IItemsRepository itemsRepository;

        public GetItemsListQueryHandler(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task<IEnumerable<ItemDto>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            return itemsRepository.GetAllItems().ToList();
        }
    }
}
