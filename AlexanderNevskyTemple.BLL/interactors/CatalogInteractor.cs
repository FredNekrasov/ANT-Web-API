using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.DAL.repositories;

namespace AlexanderNevskyTemple.BLL.interactors;
public class CatalogInteractor(CatalogRepository repository) {
    private readonly CatalogRepository _repository = repository;
    public async Task<bool?> DeleteAsync(int id) {
        var list = await _repository.GetListAsync();
        var entity = list.FirstOrDefault(i => i.Id == id);
        if(entity == null) return false;
        bool result = await _repository.DeleteAsync(entity);
        return result == false ? null : true;
    }
    public async Task<List<Catalog>> GetListAsync() => await _repository.GetListAsync();
    public async Task<bool> InsertAsync(Catalog? entity) {
        if((entity == null) || !entity.IsDataValid()) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    public async Task<bool?> UpdateAsync(int id, Catalog entity) {
        if ((entity == null) || (entity.Id != id) || !entity.IsDataValid()) return false;
        if (!await _repository.EntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}