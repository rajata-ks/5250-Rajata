using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = " Icecream scream", Description="Monster will die by this scream", Value=7 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Death by chocalate", Description="Monster dies by eating this ", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Cookie Stone", Description="Moster dies by throwning this", Value=5},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Funeral pie", Description="Monster dies by eating this", Value=2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Blackout cake", Description="Monster dies by  eatinng this", Value=6}
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> ReadAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}