using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Core
{
    public interface IInMemItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItem(Guid id);
    }
}