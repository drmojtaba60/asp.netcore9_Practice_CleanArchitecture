using MyPractice.Application.Contract.Dtos;

namespace MyPractice.Application.Contract.Interfaces;

public interface IBaseRepositoryQuery<TDto>
{
    Task<bool> ExistsAsync(int id);
    Task<List<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(int id);

    Task<PagedResult<TDto>> GetPagedAsync(PagedRequestDto request, CancellationToken cancellationToken);
}