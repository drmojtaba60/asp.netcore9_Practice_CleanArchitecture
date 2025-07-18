/*using System.Globalization;
using System.Resources;

namespace MyPractice.Localization.Helper.Evaluation.Localization.Helper;

public static class ResourceWrapper
{
    public static ResourceManager PeriodResource => GetManager(ResourceType.period);
    private static ResourceManager GetManager(ResourceType type)
    {
        ResourceManager rm = null;
        switch (type)
        {
            case ResourceType.period:
                rm = new ResourceManager("Evaluation.Localization.Resources.Period.PeriodResource", typeof(PeriodResource).Assembly);
                break;
            case ResourceType.agreement:
                break;
            case ResourceType.evaluation:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        return rm;
    }
    public static string GetItem(this ResourceManager input, string resource)
    {
        return input.GetString(resource, CultureInfo.CreateSpecificCulture("fa_IR"));
        //var type = resource.GetType();

        //switch (type.FullName.ToString())
        //{
        //    case "Period":
        //        return PeriodResource.GetString()
        //        break;
        // }
        return null;
    }
}*/