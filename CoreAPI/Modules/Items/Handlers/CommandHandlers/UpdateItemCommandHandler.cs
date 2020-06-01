using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
    {
        private readonly IItemsRepository itemsRepository;
        public UpdateItemCommandHandler(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            itemsRepository.UpdateItem(request.Id, request.Nazwa, request.Kolor, request.Cena);
            return Unit.Value;
        }
    }
}
