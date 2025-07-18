using MyPractice.CleanArchitecture.Domain.Common;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.CleanArchitecture.Domain.Entities;

public sealed class TodoList : FullAuditableEntity
{
    public TodoList()
    {
    }
    public TodoList(string title,Colour colour,int actorId,int id)
    {
        GuardAgainstValidator(title);
        Title = title;
        Colour = colour;
        Id = id;
        SetAudit(actorId);
    }
    public string Title { get; private set; } 
    public Colour Colour { get; private set; }
    public ICollection<TodoItem> TodoItems { get; private set; }
    public void Update(string title, Colour? colour=null, int? actorId=null)
    {
        Title = title;
        Colour = colour ?? Colour.White;
        SetModificationProps(actorId);
    }

    void GuardAgainstValidator(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException(nameof(title));
    }
}