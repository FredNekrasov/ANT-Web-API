using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;
using AlexanderNevskyTemple.DAL.mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.repositories;

public class ArticleRepository(ANTDbContext context, IMapper mapper) : IRepository<ArticleModel, long>
{
    private readonly ANTDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<bool> DeleteAsync(ArticleModel model)
    {
        if (_context.Contents.FirstOrDefaultAsync(i => i.ArticleId == model.Id) == null) return false;
        _context.Articles.Remove(model.ToEntity());
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<ArticleModel>> GetListAsync() {
        List<ArticleModel> articleModels = [];
        var articles = await _context.Articles.ToListAsync();
        foreach (var article in articles) {
            var catalog = await _context.Catalogs.FindAsync(article.CatalogId);
            var articleModel = new ArticleModel {
                Id = article.Id,
                Catalog = _mapper.Map<CatalogModel>(catalog),
                Title = article.Title,
                Description = article.Description,
                DateOrBanner = article.DateOrBanner
            };
            articleModels.Add(articleModel);
        }
        return articleModels;
    }
    public async Task InsertAsync(ArticleModel model)
    {
        await _context.Articles.AddAsync(model.ToEntity());
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateAsync(ArticleModel model)
    {
        _context.Entry(model.ToEntity()).State = EntityState.Modified;
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
    public async Task<bool> EntityExistsAsync(long id) => await _context.Articles.AnyAsync(e => e.Id == id);
}