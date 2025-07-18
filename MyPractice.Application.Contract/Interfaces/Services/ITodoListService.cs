﻿using MyPractice.Application.Contract.Dtos;

namespace MyPractice.Application.Contract.Interfaces.Services;

public interface ITodoListService
{
    Task<List<TodoListDto>> GetAllAsync();

    Task<PagedResult<TodoListDto>> GetAllPaginationAsync(PagedRequestDto pagedRequestDto,
        CancellationToken cancellationToken);
    Task<TodoListDto?> GetByIdAsync(int id);
    Task<int> AddAsync(TodoListDto todoListDto);
    Task UpdateAsync(TodoListDto todoListDto);
    Task DeleteAsync(int id);
}