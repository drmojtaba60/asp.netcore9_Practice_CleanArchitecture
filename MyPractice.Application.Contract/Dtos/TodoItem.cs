using MyPractice.Application.Contract.Command;
using MyPractice.CleanArchitecture.Domain.Enums;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.Application.Contract.Dtos;

public record TodoItem : BaseDto<int>
{
    public int ListId { get;  set; }
    public string Title { get;  set; }=string.Empty;
    public string? Description { get; set; }
    public PriorityLevel Priority { get;  set; } 
    public DateTime? Reminder { get;  set; }
    public bool Done { get;  set; }

    public TodoListDto List { get; set; } = null!;

}