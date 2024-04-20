﻿using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.DAL.repositories;

namespace AlexanderNevskyTemple.BLL.interactors;
public class ContentInteractor(ContentRepository repository) {
    private readonly ContentRepository _repository = repository;
    public async Task<bool> DeleteAsync(Guid id) {
        var list = await _repository.GetListAsync();
        var entity = list.FirstOrDefault(i => i.Id == id);
        if(entity == null) return false;
        await _repository.DeleteAsync(entity);
        return true;
    }
    public async Task<List<Content>> GetListAsync() => await _repository.GetListAsync();
    public async Task<bool> InsertAsync(Content? entity) {
        if(entity == null) return false;
        await _repository.InsertAsync(entity);
        return true;
    }
    public async Task<bool?> UpdateAsync(Guid id, Content entity) {
        if (entity.Id != id) return false;
        if (!await _repository.EntityExistsAsync(id)) return null;
        return await _repository.UpdateAsync(entity);
    }
}