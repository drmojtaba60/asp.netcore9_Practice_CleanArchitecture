using MyPractice.Application.Contract.Dtos;

namespace MyPractice.Application.Contract.Interfaces;

public interface ITodoListRepositoryQuery : IBaseRepositoryQuery<TodoListDto>
{
    

    public Task<bool> ExistsByTitleAsync(string title);

    public Task<bool> IsDuplicatedByTitleAsync(string title, int? id);
}