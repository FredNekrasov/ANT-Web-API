using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories.impl;

public class CatalogRepository(ANTDbContext context) : IRepository<Catalog, int>
{
    private readonly ANTDbContext _context = context;
    public async Task<bool> DeleteAsync(Catalog entity)
    {
        if (_context.Articles.FirstOrDefaultAsync(i => i.CatalogId == entity.Id) == null) return false;
        _context.Catalogs.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<Catalog>> GetListAsync() => await _context.Catalogs.ToListAsync();
    public async Task InsertAsync(Catalog entity)
    {
        await _context.Catalogs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(Catalog entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> EntityExistsAsync(int id) => await _context.Catalogs.AnyAsync(e => e.Id == id);
}