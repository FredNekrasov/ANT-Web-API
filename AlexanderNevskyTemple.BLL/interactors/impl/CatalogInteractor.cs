using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;

namespace AlexanderNevskyTemple.BLL.interactors.impl;
public class CatalogInteractor(IRepository<CatalogModel, int> repository) : IInteractor<CatalogModel, int>
{
    private readonly IRepository<CatalogModel, int> _repository = repository;
    public async Task<bool?> DeleteAsync(int id)
    {
        var list = await _repository.GetListAsync();
        var entity = list.FirstOrDefault(i => i.Id == id);
        if (entity == null) return false;
        bool result = await _repository.DeleteAsync(entity);
        return result == false ? null : true;
    }
    public async Task<List<CatalogModel>> GetListAsync() => await _repository.GetListAsync();
    public async Task<bool> InsertAsync(CatalogModel? entity)
    {
        if (entity == null || !entity.IsDataValid()) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    public async Task<bool?> UpdateAsync(int id, CatalogModel entity)
    {
        if (entity == null || entity.Id != id || !entity.IsDataValid()) return false;
        if (!await _repository.EntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}