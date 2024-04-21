using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class ArticleRepository(ANTDbContext context) {
    private readonly ANTDbContext _context = context;
    public async Task<bool> DeleteAsync(Article entity) {
        if(_context.Contents.FirstOrDefaultAsync(i => i.ArticleId == entity.Id) == null) return false;
        _context.Articles.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<Article>> GetListAsync() => await _context.Articles.ToListAsync();
    public async Task InsertAsync(Article entity) {
        await _context.Articles.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(Article entity) {
        _context.Entry(entity).State = EntityState.Modified;
        try {
            await _context.SaveChangesAsync();
        } catch(DbUpdateConcurrencyException) {
            return false;
        }
        return true;
    }
    public async Task<bool> EntityExistsAsync(long id) => await _context.Articles.AnyAsync(e => e.Id == id);
}