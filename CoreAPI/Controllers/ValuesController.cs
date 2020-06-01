using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CoreAPI.Modules.Items;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("items-list")]
        public async Task<IActionResult> GetItemsList()
        {
            var query = new GetItemsListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("item")]
        public async Task<IActionResult> GetItem([FromQuery] int itemId)
        {
            var query = new GetItemQuery(itemId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("add-item")]
        public Task AddNewItem([FromBody] AddItemCommand command)
        {
            return _mediator.Send(command);
        }


        [HttpPut]
        [Route("update-item")]
        public Task UpdateItem([FromBody] UpdateItemCommand command)
        {
            return _mediator.Send(command);
        }
        [HttpDelete]
        [Route("delete-item")]
        public Task DeleteItem(DeleteItemCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
