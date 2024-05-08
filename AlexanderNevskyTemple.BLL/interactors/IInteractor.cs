namespace AlexanderNevskyTemple.BLL.interactors;
public interface IInteractor<M, E> {
    Task<bool?> DeleteAsync(E id);
    Task<List<M>> GetListAsync();
    Task<bool> InsertAsync(M? entity);
    Task<bool?> UpdateAsync(E id, M entity);
}