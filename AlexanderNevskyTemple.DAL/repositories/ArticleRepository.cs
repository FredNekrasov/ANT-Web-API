﻿using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class ArticleRepository(ANTDbContext context) {
    private readonly ANTDbContext _context = context;
    public async Task DeleteAsync(Article entity) {
        _context.Articles.Remove(entity);
        await _context.SaveChangesAsync();
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
    public async Task<bool> EntityExistsAsync(int id) => await _context.Catalogs.AnyAsync(e => e.Id == id);
}