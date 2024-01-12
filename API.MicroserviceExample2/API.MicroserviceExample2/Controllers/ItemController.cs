using API.Application.Commands.Item;
using API.Application.DTOs;
using API.Application.Querys.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetById(int id)
        {
            var query = new GetItemByIdQuery(id);
            var Item = await _mediator.Send(query);

            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAll()
        {
            var query = new GetAllItemsQuery();
            var Items = await _mediator.Send(query);
            return Ok(Items);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItem(CreateItemCommand command)
        {
            var Item = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = Item.Id }, Item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDTO>> UpdateItem(int id, UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var updatedItem = await _mediator.Send(command);

            if (updatedItem == null)
            {
                return NotFound();
            }

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _mediator.Send(new DeleteItemCommand(id));
            return NoContent();
        }
    }
}