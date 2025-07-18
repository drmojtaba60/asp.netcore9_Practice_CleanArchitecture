using MyPractice.CleanArchitecture.Domain.Common;
using MyPractice.CleanArchitecture.Domain.Enums;

namespace MyPractice.CleanArchitecture.Domain.Entities;

public sealed class TodoItem : AuditableSoftDeleteEntity
{
    public int ListId { get; private set; }
    public string Title { get; private set; }=string.Empty;
    public string? Description { get;private set; }
    public PriorityLevel Priority { get; private set; } 
    public DateTime? Reminder { get; private set; }
    public bool Done { get; private set; }

    public TodoList List { get; private set; } 

    public TodoItem()
    {
        
    }

    public TodoItem(int listId, string? description, PriorityLevel priority, DateTime? reminder,int actorId,int id=0)
    {
        ListId = listId;
        Description = description;
        Priority = priority;
        Reminder = reminder;
        Done = true;
        Id = id;
        
        SetAudit(actorId);
    }
    public void Update(string? description, PriorityLevel priority, DateTime? reminder,int actorId)
    {
        Description = description;
        Priority = priority;
        Reminder = reminder;
        
        SetModificationProps(actorId);
    }

    public void ChangePriority(PriorityLevel priority, int actorId)
    {
        SetModificationProps(actorId);
        Priority = priority;
    }
    public void SetDone(bool done,int actorId)
    {
        SetModificationProps(actorId);
        Done = done;
    }
}