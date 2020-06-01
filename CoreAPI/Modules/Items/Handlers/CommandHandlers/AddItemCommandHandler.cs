using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Unit>
    {
        private readonly IItemsRepository itemsRepository;
        public AddItemCommandHandler(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            itemsRepository.AddItem(request.Nazwa, request.Kolor, request.Cena);
            return Unit.Value;
        }
    }
}
