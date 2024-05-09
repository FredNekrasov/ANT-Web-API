using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;
using AlexanderNevskyTemple.DAL.entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class CatalogRepository(ANTDbContext context, IMapper mapper) : IRepository<CatalogModel, int>
{
    private readonly ANTDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<bool> DeleteAsync(CatalogModel model)
    {
        if (_context.Articles.FirstOrDefaultAsync(i => i.CatalogId == model.Id) == null) return false;
        _context.Catalogs.Remove(_mapper.Map<Catalog>(model));
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<CatalogModel>> GetListAsync() => _mapper.Map<List<CatalogModel>>(await _context.Catalogs.ToListAsync());
    public async Task InsertAsync(CatalogModel model)
    {
        await _context.Catalogs.AddAsync(_mapper.Map<Catalog>(model));
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(CatalogModel model)
    {
        _context.Entry(_mapper.Map<Catalog>(model)).State = EntityState.Modified;
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