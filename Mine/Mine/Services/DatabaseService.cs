using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine.Models;
using SQLite;

namespace Mine.Services
{
    public class DatabaseService:IDataStore<ItemModel>
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        ///CreateAsync will write to the table and it returns the ID of what was written
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if(item==null)
            {
                return false;
            }

            //InsertAsync will write to the table 
            var result = await Database.InsertAsync(item);
            if (result == 0)
            {
                return false;
            }
            return true;
        }


        ///UpdateAsync will update item in the table 
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            //UpdateAsync will update an item in the table 
            var result = await Database.UpdateAsync(item);
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        ///DeleteAsync will delete an item from the table given id 
        public async Task<bool> DeleteAsync(string id)
        {
            var data = await ReadAsync(id);
            if (data == null)
            {
                return false;
            }

           //DeleteAsync will delete an item from the table given id 
            var result = await Database.DeleteAsync(data);
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        ///ReadAsync will Read details of an item from the table given id 
        public Task<ItemModel> ReadAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            //Call the Database to read the ID 
            //Using Linq sytax Find the first record that has the ID that matches
            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));
            return result;
        }

        ///IndexAsync will retrive item list  
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            var result = await Database.Table<ItemModel>().ToListAsync(); 
            return result;
        }
    }
}


