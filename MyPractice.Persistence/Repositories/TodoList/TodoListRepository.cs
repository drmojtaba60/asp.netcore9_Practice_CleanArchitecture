using MyPractice.CleanArchitecture.Domain.Entities;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

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