using MyPractice.Application.Contract.Dtos;
using MyPractice.Application.Contract.Exceptions;
using MyPractice.Application.Contract.Interfaces;
using MyPractice.Application.Contract.Interfaces.Services;
using MyPractice.CleanArchitecture.Domain.Entities;

namespace MyPractice.Application.Services;

public class TodoListService(
    ITodoListRepository todoListRepository,
    ITodoListRepositoryQuery todoListRepositoryQuery)
    : ITodoListService
{
    public async Task<List<TodoListDto>> GetAllAsync()
    {
        return await todoListRepositoryQuery.GetAllAsync();
    }

    public async Task<TodoListDto?> GetByIdAsync(int id)
    {
        return await todoListRepositoryQuery.GetByIdAsync(id);
    }

    public async Task<int> AddAsync(TodoListDto todoListDto)
    {
        if (string.IsNullOrEmpty(todoListDto?.Title))
            throw new TodoListTitleNullException();
        if (await todoListRepositoryQuery.ExistsByTitleAsync(todoListDto.Title))
            throw new Exception("Title already exists");
        var todoList = new TodoList(todoListDto?.Title ?? "", todoListDto.Colour, 0, 0);
        await todoListRepository.AddAsync(todoList);
        return todoList.Id;
    }

    public async Task UpdateAsync(TodoListDto todoListDto)
    {
        if (!await todoListRepositoryQuery.ExistsAsync(todoListDto.Id))
            throw new Exception("Id not found");
        if (await todoListRepositoryQuery.IsDuplicatedByTitleAsync(todoListDto.Title, todoListDto.Id))
            throw new Exception("Title already exists");
        var todoList = new TodoList(todoListDto?.Title ?? "", todoListDto.Colour, 0, todoListDto.Id);
        await todoListRepository.UpdateAsync(todoList);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await todoListRepositoryQuery.ExistsAsync(id))
            throw new Exception("Id not found");
        var todoList = new TodoList("", null, 0, id);
        await todoListRepository.DeleteAsync(todoList);
    }

    public async Task<PagedResult<TodoListDto>> GetAllPaginationAsync(PagedRequestDto pagedRequestDto,
        CancellationToken cancellationToken)
    {
        var r= await todoListRepositoryQuery.GetPagedAsync(pagedRequestDto, cancellationToken);
        return r;
    }
}