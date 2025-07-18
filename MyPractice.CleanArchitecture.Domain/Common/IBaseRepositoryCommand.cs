namespace MyPractice.CleanArchitecture.Domain.Common;

public interface IBaseRepositoryCommand<T>
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}