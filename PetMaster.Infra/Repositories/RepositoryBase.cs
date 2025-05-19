using Microsoft.EntityFrameworkCore;
using PetMaster.Domain.Entities;
using PetMaster.Domain.Repositories;
using PetMaster.Infra.Context;

namespace PetMaster.Infra.Repositories;
public abstract class RepositoryBase<T>(PetMasterContext context) 
    : IRepositoryBase<T> where T 
    : Entity
{
    private readonly PetMasterContext _context = context;

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id) 
    {
        await _context.Set<T>().Where(t => t.Id == id).ExecuteDeleteAsync(CancellationToken.None);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>()
        .AsNoTracking()
        .ToListAsync(CancellationToken.None);

    public Task<T?> GetByIdAsync(Guid id) => _context.Set<T>()
        .FirstOrDefaultAsync(t => t.Id == id, CancellationToken.None);

    public async Task<bool> UpdateAsync(Guid id, T entity)
    {
        T? val = await GetByIdAsync(id);
        
        if (val is not null) 
        {
            _context.Entry(val).CurrentValues.SetValues(entity);
            _context.Entry(val).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
