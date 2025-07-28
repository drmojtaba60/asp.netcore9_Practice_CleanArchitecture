using MyPractice.Application.Contract.Command;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.Application.Contract.Dtos;

public record TodoListDto(int Id, string Title, Colour Colour) : BaseDto<int>(Id);
