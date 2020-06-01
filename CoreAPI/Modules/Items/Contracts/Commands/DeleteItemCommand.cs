using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Modules.Items
{
    public class DeleteItemCommand : IRequest<Unit>
    {
        public DeleteItemCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
