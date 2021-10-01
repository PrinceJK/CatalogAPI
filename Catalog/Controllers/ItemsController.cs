using Catalog.Core;
using Catalog.Core.DTO;
using Catalog.Core.Mapping;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            _repository = repository;
        }

        //Get all items
        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            var items = (await _repository.GetItemsAsync()).Select(item => item.AsDTO());

            return items;
        }

        //Get items by Id
        [HttpGet("id")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            return item.AsDTO();
        }

        //Create Items
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItemAsync([FromForm]CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreadedDate = DateTimeOffset.Now
            };

            await _repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDTO());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item updatedIte = existingItem with
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };
            await _repository.UpdateItemAsync(updatedIte);
            return NoContent();
        }

        //Delete Item
        [HttpDelete]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await _repository.DeleteItem(id);

            return NoContent();
        }
    }
}
