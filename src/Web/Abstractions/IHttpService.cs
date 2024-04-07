namespace Fiap.UI.Escola.Web.Abstractions;

public interface IHttpService<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task InsertAsync(TEntity turma);

    Task UpdateAsync(int id, TEntity turma);

    Task DeleteAsync(int id);
}
