using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IItemsRepository itemsRepository;

        public DeleteItemCommandHandler(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            itemsRepository.DeleteItem(request.Id);
            return Unit.Value;
        }
    }
}
