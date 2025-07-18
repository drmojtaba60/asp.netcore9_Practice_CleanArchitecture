namespace MyPractice.Application.Contract.Command;

public record BaseDto<T>
{
    public T Id { get; set; }=default!;
}