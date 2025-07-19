using MyPractice.CleanArchitecture.Domain.Enums;

namespace MyPractice.Application.Contract.Command;


public class BaseException : Exception
{
    public ResourceType ResourceType { get; }
    public string ResourceKey { get; }

    public BaseException(ResourceType resourceType, string resourceKey)
    {
        ResourceType = resourceType;
        ResourceKey = resourceKey;
    }
}
