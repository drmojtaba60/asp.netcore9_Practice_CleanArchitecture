using MyPractice.Application.Contract.Dtos;

namespace MyPractice.Application.Contract.Interfaces;

public interface ITodoListRepositoryQuery : IBaseRepositoryQuery<TodoListDto>
{
    

    Task<bool> ExistsByTitleAsync(string title);

    Task<bool> IsDuplicatedByTitleAsync(string title, int? id);
    
}