using Microsoft.EntityFrameworkCore;
using MyPractice.Application.Contract.Dtos;
using MyPractice.Application.Contract.Interfaces;
using MyPractice.Application.Contract.Mappers;
using MyPractice.CleanArchitecture.Domain.Entities;

namespace MyPractice.Persistant.Repositories;

public class TodoListRepository(ApplicationDbContext context) : ITodoListRepository
{
    public async Task AddAsync(TodoList entity)
    {
        await context.TodoLists.AddAsync(entity);
    }

    public async Task UpdateAsync(TodoList todoList)
    {
        var entry = await context.TodoLists.FindAsync(todoList.Id);
        entry?.Update(todoList.Title, todoList.Colour, 0);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoList todoList)
    {
        var entry = await context.TodoLists.FindAsync(todoList.Id);
        entry?.Update(todoList.Title, todoList.Colour, 0);
        await context.SaveChangesAsync();
    }
}

public class TodoListRepositoryQuery(ApplicationDbContext _context) : ITodoListRepositoryQuery
{
    public async Task<List<TodoListDto>> GetAllSimpleMappingAsync()
    {
        return await _context.TodoLists.AsNoTracking().Select(q => new TodoListDto(q.Id, q.Title, q.Colour))
            .ToListAsync();
    }

    public async Task<List<TodoListDto>> GetAllAsync() =>
        await _context.TodoLists
            .AsNoTracking()
            .Select(TodoListMapper.ToDto)
            .ToListAsync();

    public async Task<TodoListDto?> GetByIdSimpleMapperAsync(int id)
    {
        return await _context.TodoLists
            .AsNoTracking()
            .Where(q => q.Id == id)
            .Select(q => new TodoListDto(q.Id, q.Title, q.Colour)).FirstOrDefaultAsync();
    }

    public async Task<TodoListDto?> GetByIdAsync(int id) =>
        await _context.TodoLists
            .AsNoTracking()
            .Where(q => q.Id == id)
            .Select(TodoListMapper.ToDto)
            .FirstOrDefaultAsync();

    public async Task<bool> ExistsAsync(int id) => await _context.TodoLists.AsNoTracking().AnyAsync(q => q.Id == id);

    public async Task<bool> ExistsByTitleAsync(string title) =>
        await _context.TodoLists.AsNoTracking().AnyAsync(q => q.Title == title);

    public async Task<bool> IsDuplicatedByTitleAsync(string title, int? id) =>
        await _context.TodoLists.AsNoTracking().AnyAsync(q => q.Title == title && (id == null || q.Id != id));

}