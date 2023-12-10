using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameHub.Utils
{
    public enum RamMemory
    {
        [Display(Name = "8 GB RAM")]
        RAM8 = 8,

        [Display(Name = "16 GB RAM")]
        RAM16 = 16,

        [Display(Name = "32 GB RAM")]
        RAM32 = 32,

        [Display(Name = "64 GB RAM")]
        RAM64 = 64,
    }

    public static class RamMemoryValue
    {
        public static string GetRamemoryValue(RamMemory ram)
        {
            FieldInfo fieldInfo = ram.GetType().GetField(ram.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            string ramValue = displayAttribute?.Name ?? ram.ToString();
            return ramValue;
        }
    }
}
