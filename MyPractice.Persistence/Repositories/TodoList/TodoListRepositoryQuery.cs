using Microsoft.EntityFrameworkCore;
using MyPractice.Application.Contract.Dtos;
using MyPractice.Application.Contract.Interfaces;
using MyPractice.Application.Contract.Mappers;

namespace MyPractice.Persistant.Repositories;

public class TodoListRepositoryQuery(ApplicationDbContext context) : ITodoListRepositoryQuery
{
    public async Task<List<TodoListDto>> GetAllSimpleMappingAsync()=>
        await context.TodoLists
            .AsNoTracking()
            .Select(q => new TodoListDto(q.Id, q.Title,q.Colour))
            .ToListAsync();

    public async Task<List<TodoListDto>> GetAllAsync() =>
        await context.TodoLists
            .AsNoTracking()
            .Select(TodoListMapper.ToDto)
            .ToListAsync();

    public async Task<TodoListDto?> GetByIdSimpleMapperAsync(int id)
    {
        return await context.TodoLists
            .AsNoTracking()
            .Where(q => q.Id == id)
            .Select(q => new TodoListDto(q.Id, q.Title, q.Colour)).FirstOrDefaultAsync();
    }

    public async Task<TodoListDto?> GetByIdAsync(int id) =>
        await context.TodoLists
            .AsNoTracking()
            .Where(q => q.Id == id)
            .Select(TodoListMapper.ToDto)
            .FirstOrDefaultAsync();

    public async Task<bool> ExistsAsync(int id) => await context.TodoLists.AsNoTracking().AnyAsync(q => q.Id == id);

    public async Task<bool> ExistsByTitleAsync(string title) =>
        await context.TodoLists.AsNoTracking().AnyAsync(q => q.Title == title);

    public async Task<bool> IsDuplicatedByTitleAsync(string title, int? id) =>
        await context.TodoLists.AsNoTracking().AnyAsync(q => q.Title == title && (id == null || q.Id != id));
    
    
    public async Task<PagedResult<TodoListDto>> GetPagedAsync(PagedRequestDto request, CancellationToken cancellationToken)
    {
        var query = context.TodoLists.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(p => p.Title)
            .Skip(request.Skip)
            .Take(request.PageSize)
            .Select(TodoListMapper.ToDto)
            .ToListAsync(cancellationToken);

        return new PagedResult<TodoListDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }


}