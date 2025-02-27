using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.DataAccess.Context;
using GemSoftDemoApp.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace GemSoftDemoApp.DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<int> Count()
        {
            return await Table.CountAsync();
        }

        public async Task<HttpStatusCode> Create(T entity)
        {
            bool exists = await Table.AnyAsync(x => x.Title == entity.Title);
            if (exists)
                return HttpStatusCode.Conflict;

            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity is null)
                return HttpStatusCode.NotFound;

            Table.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        public async Task<int> FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).CountAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<List<T>> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetList()
        {
            return await Table.ToListAsync();
        }

        public async Task<HttpStatusCode> Update(T entity)
        {
            var existingEntity = await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity is null)
                return HttpStatusCode.NotFound;

            bool exists = await Table.AnyAsync(x => x.Id != entity.Id & x.Title == entity.Title);
            if (exists)
                return HttpStatusCode.Conflict;

            Table.Attach(entity);// Sadece değişen alanları güncelle
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
