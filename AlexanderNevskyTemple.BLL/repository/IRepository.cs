namespace AlexanderNevskyTemple.BLL.repository;
public interface IRepository<M, I> {
    Task InsertAsync(M model);
    Task<bool> DeleteAsync(M model);
    Task<List<M>> GetListAsync();
    Task<bool> UpdateAsync(M model);
    Task<bool> EntityExistsAsync(I id);
}