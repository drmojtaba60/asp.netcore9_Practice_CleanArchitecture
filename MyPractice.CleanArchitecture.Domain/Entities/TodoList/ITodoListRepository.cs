using MyPractice.CleanArchitecture.Domain.Common;

namespace MyPractice.CleanArchitecture.Domain.Entities;

public interface ITodoListRepository : IBaseRepositoryCommand<TodoList>
{
}