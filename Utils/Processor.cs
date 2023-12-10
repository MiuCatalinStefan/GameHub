using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameHub.Utils
{
    public enum Processor
    {
        [Display(Name = "Intel Core i5")]
        IntelCoreI5 = 1,

        [Display(Name = "Intel Core 2")]
        IntelCore2 = 2,

        [Display(Name = "Intel Core i7")]
        IntelCoreI7 = 3,

        [Display(Name = "AMD® Ryzen™ 5")]
        AmdRyzen5 = 4,

        [Display(Name = "AMD® Ryzen™ 7")]
        AmdRyzen7 = 5,
    }

    public static class ProcessorValue
    {
        public static string GetProcessorValue(Processor p)
        {
            FieldInfo fieldInfo = p.GetType().GetField(p.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            string pValue = displayAttribute?.Name ?? p.ToString();
            return pValue;
        }
    }
}
