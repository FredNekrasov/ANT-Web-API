using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class ContentRepository(ANTDbContext context) {
    private readonly ANTDbContext _context = context;
    public async Task DeleteAsync(Content entity) {
        _context.Contents.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Content>> GetListAsync() => await _context.Contents.ToListAsync();
    public async Task InsertAsync(Content entity) {
        await _context.Contents.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(Content entity) {
        _context.Entry(entity).State = EntityState.Modified;
        try {
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException) {
            return false;
        }
        return true;
    }
    public async Task<bool> EntityExistsAsync(Guid id) => await _context.Contents.AnyAsync(e => e.Id == id);
}