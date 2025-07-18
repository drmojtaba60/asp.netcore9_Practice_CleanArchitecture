namespace MyPractice.CleanArchitecture.Domain.Common;

public abstract class AuditableEntity : AuditableEntity<int>
{
}

public abstract class AuditableEntity<T> : BaseEntity<T> where T : struct
{
    public int? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    protected void SetAudit(int? createdBy)
    {
        CreatedBy = createdBy;
        CreatedDate = DateTime.Now;
    }

    protected void SetModificationProps(int? modifiedBy)
    {
        ModifiedBy = modifiedBy;
        ModifiedDate = DateTime.Now;
    }
}

public abstract class AuditableSoftDeleteEntity : AuditableEntity
{
    
    public int? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } =false;

    public void Delete(int actorId)
    {
        IsDeleted = true;
        DeletedBy=actorId;
    }
}

public abstract class AuditableActiveEntity : AuditableEntity
{
    public bool IsActive { get; set; }
    public void Activate(int actorId)
    {
        SetModificationProps(actorId);
        IsActive = true;
    }

    public void DeActivate(int actorId)
    {
        SetModificationProps(actorId);
        IsActive = false;
    }
}
public abstract class FullAuditableEntity : AuditableEntity
{
    public bool IsActive { get; set; }
    public int? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } =false;

    public void Delete(int actorId)
    {
        IsDeleted = true;
        DeletedBy=actorId;
    }
    public void Activate(int actorId)
    {
        SetModificationProps(actorId);
        IsActive = true;
    }

    public void DeActivate(int actorId)
    {
        SetModificationProps(actorId);
        IsActive = false;
    }
}
public abstract class AuditableActiveEntity<T> : AuditableEntity<T> where T : struct
{
    public bool IsActive { get; set; }
}
public abstract class AuditableSoftDeleteEntity<T> : AuditableSoftDeleteEntity where T : struct
{
}