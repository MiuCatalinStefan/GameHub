using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameHub.Utils
{
    public enum Platform
    {
        [Display(Name = "PlayStation 5")]
        PS5 = 1,

        [Display(Name = "PlayStation 4")]
        PS4 = 2,

        [Display(Name = "Xbox Series X/S")]
        XBOX = 3,

        [Display(Name = "Nintendo Switch")]
        NINTENDO = 4,

        [Display(Name = "PC")]
        PC = 5
    }

    public static class PlatformValue
    {
        public static string getPlatformName(Platform platform)
        {
            // Obține FieldInfo pentru membrul enum-ului
            FieldInfo fieldInfo = platform.GetType().GetField(platform.ToString());

            // Obține atributul Display
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            // Extrage numele din atribut
            string displayName = displayAttribute?.Name ?? platform.ToString();

            return displayName;
        }
    }


}
