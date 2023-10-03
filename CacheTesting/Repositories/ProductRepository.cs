using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Web.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext context;
        private IMemoryCache cache;

        public ProductRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            this.cache = cache;
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetAll() => await context.Products.ToListAsync();

        public async Task<Product> Get(Guid id)
        {
            Product product;
            if (!cache.TryGetValue(id,out product))
            {
                var result = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) throw new ProductNotFoundException();
                cache.Set(result.Id, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(365)
                });
                return result;
            }

            return product;
        }

        public async Task Add(Product entity)
        {
            var result = await context.Products.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (result == null) throw new ProductNotFoundException();

            context.Products.Add(entity);
            await context.SaveChangesAsync();
            cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(365)
            });
        }

        public async Task Delete(Guid id)
        {
            var result = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) throw new ProductNotFoundException();

            context.Products.Remove(new Product { Id = id });
            await context.SaveChangesAsync();
            cache.Remove(id);
        }

        public async Task Edit(Product entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
            cache.Set(entity.Id, entity, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(365)
            });
        }
    }
}
