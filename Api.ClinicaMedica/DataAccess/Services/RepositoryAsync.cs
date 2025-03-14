using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.ClinicaMedica.DataAccess.Services
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public async Task<T> Delete(object id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> ExistById(object? id)
        {
            var entity = await GetById(id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = EntitySet;
            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<T> GetById(object? id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> GetById(int? id, params Expression<Func<T, object>>[] includes)
        {
            if (id == null)
                return null;

            if (includes == null || !includes.Any())
            {
                return await EntitySet.FindAsync(id);
            }
            else
            {
                IQueryable<T> query = EntitySet;

                foreach (var include in includes)
                    query = query.Include(include);

                return await query.SingleOrDefaultAsync(e => e == EntitySet.Find(id));
            }
        }

        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }
    }
}
