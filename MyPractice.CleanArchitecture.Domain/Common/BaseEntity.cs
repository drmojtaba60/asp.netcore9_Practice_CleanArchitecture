namespace MyPractice.CleanArchitecture.Domain.Common;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; set; }=default!;
}
public abstract class BaseEntity : BaseEntity<int>
{
}