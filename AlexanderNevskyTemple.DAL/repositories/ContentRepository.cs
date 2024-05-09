using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;
using AlexanderNevskyTemple.DAL.entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class ContentRepository(ANTDbContext context, IMapper mapper) : IRepository<ContentModel, long>
{
    private readonly ANTDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<bool> DeleteAsync(ContentModel model)
    {
        _context.Contents.Remove(_mapper.Map<Content>(model));
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<ContentModel>> GetListAsync() => _mapper.Map<List<ContentModel>>(await _context.Contents.ToListAsync());
    public async Task InsertAsync(ContentModel model)
    {
        await _context.Contents.AddAsync(_mapper.Map<Content>(model));
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(ContentModel model)
    {
        _context.Entry(_mapper.Map<Content>(model)).State = EntityState.Modified;
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
    public async Task<bool> EntityExistsAsync(long id) => await _context.Contents.AnyAsync(e => e.Id == id);
}