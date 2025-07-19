using MyPractice.Application.Contract.Interfaces;
using MyPractice.CleanArchitecture.Domain.Enums;

namespace MyPractice.Localization.Helper;

using System.Globalization;
using System.Resources;
using System.Reflection;

public class Localizer : ILocalizer
{
    public string GetLocalized(ResourceType type, string key)
    {
        var baseName = $"MyPractice.Localization.Resources.{type}";//$"Infrastructure.Localization.Resources.{type}";
        var rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
        return rm.GetString(key, CultureInfo.CurrentUICulture) ?? $"[MISSING:{key}]";
    }
}
