using System.Linq.Expressions;
using MyPractice.Application.Contract.Dtos;
using MyPractice.CleanArchitecture.Domain.Entities;

namespace MyPractice.Application.Contract.Mappers;

public static class TodoListMapper
{
    public static readonly Expression<Func<TodoList, TodoListDto>> ToDto =
        q => new TodoListDto(q.Id, q.Title, q.Colour);
}