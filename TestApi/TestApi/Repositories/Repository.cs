﻿using Microsoft.EntityFrameworkCore;
using TestApi.Repositories.Interfaces;

namespace TestApi.Repositories
{
    public class   Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ProductContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> FindByNameAsync(string name)
        {
            // This is a placeholder implementation. Actual implementation might vary based on T's properties.
            return await _dbSet.ToListAsync();
        }
    }
}
