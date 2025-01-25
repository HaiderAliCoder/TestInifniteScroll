using TestInifniteScroll.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace TestInifniteScroll.Data
{
    public class ItemRepository
    {
        private readonly ForumDbContext _context;

        public ItemRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItemsAsync(int offset, int pageSize)
        {
            var items = await _context.Items
        .FromSqlRaw("EXEC GetItems @Offset = {0}, @PageSize = {1}", offset, pageSize)
        .ToListAsync();
            return items;
        }
    }
}
