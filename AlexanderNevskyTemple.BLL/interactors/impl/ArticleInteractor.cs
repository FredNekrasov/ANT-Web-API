using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;

namespace AlexanderNevskyTemple.BLL.interactors.impl;
public class ArticleInteractor(IRepository<ArticleModel, long> repository) : IInteractor<ArticleModel, long>
{
    private readonly IRepository<ArticleModel, long> _repository = repository;
    public async Task<bool?> DeleteAsync(long id)
    {
        var list = await _repository.GetListAsync();
        var entity = list.FirstOrDefault(i => i.Id == id);
        if (entity == null) return false;
        bool result = await _repository.DeleteAsync(entity);
        return result == false ? null : true;
    }
    public async Task<List<ArticleModel>> GetListAsync() => await _repository.GetListAsync();
    public async Task<bool> InsertAsync(ArticleModel? entity)
    {
        if (entity == null || !entity.IsDataValid()) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    public async Task<bool?> UpdateAsync(long id, ArticleModel entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.EntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}