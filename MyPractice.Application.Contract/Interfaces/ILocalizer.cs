using MyPractice.CleanArchitecture.Domain.Enums;

namespace MyPractice.Application.Contract.Interfaces;

public interface ILocalizer
{
    string GetLocalized(ResourceType type, string key);
}