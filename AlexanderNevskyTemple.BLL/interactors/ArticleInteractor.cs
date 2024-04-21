using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.DAL.repositories;

namespace AlexanderNevskyTemple.BLL.interactors;
public class ArticleInteractor(ArticleRepository repository) {
    private readonly ArticleRepository _repository = repository;
    public async Task<bool> DeleteAsync(long id) {
        var list = await _repository.GetListAsync();
        var entity = list.FirstOrDefault(i => i.Id == id);
        if(entity == null) return false;
        await _repository.DeleteAsync(entity);
        return true;
    }
    public async Task<List<Article>> GetListAsync() => await _repository.GetListAsync();
    public async Task<bool> InsertAsync(Article? entity) {
        if((entity == null) || !entity.IsDataValid()) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    public async Task<bool?> UpdateAsync(long id, Article entity) {
        if ((entity == null) || (entity.Id != id) || !entity.IsDataValid()) return false;
        if (!await _repository.EntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}