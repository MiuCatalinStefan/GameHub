using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameHub.Utils
{
    public enum OperatingSystem
    {
        [Display(Name = "Windows 10 64-Bit")]
        Windows10_64Bit = 1,

        [Display(Name = "Windows 10 32-Bit")]
        Windows10_32Bit = 2,

        [Display(Name = "Windows 11 64-Bit")]
        Windows11_64Bit = 3,

        [Display(Name = "Windows 11 32-Bit")]
        Windows11_32Bit = 4,

        [Display(Name = "Windows 8 32-Bit")]
        Windows8_32Bit = 5,

        [Display(Name = "Windows 8 64-Bit")]
        Windows8_64Bit = 6
    }

    public static class OperatingSystemsValue
    {
        public static string getOsValue(OperatingSystem os)
        {
            FieldInfo fieldInfo = os.GetType().GetField(os.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            string osValue = displayAttribute?.Name ?? os.ToString();
            return osValue;
        }
    }
}