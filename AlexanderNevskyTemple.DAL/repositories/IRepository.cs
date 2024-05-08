namespace AlexanderNevskyTemple.DAL.repositories;
public interface IRepository<E, I> {
    Task InsertAsync(E entity);
    Task<bool> DeleteAsync(E entity);
    Task<List<E>> GetListAsync();
    Task<bool> UpdateAsync(E entity);
    Task<bool> EntityExistsAsync(I id);
}