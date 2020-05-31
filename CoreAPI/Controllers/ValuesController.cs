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

        //[HttpGet]
        //[Route("item")]
        //public Task<ItemDto> GetItem(int itemId)
        //{

        //}

        //[HttpPost]
        //public void AddNewItem([FromBody] string value)
        //{
        //}

        
        //[HttpPut]
        //public void UpdateItem(int id, [FromBody] string value)
        //{
        //}

        
        //[HttpDelete]
        //public void DeleteItem(int id)
        //{
        //}
    }
}
