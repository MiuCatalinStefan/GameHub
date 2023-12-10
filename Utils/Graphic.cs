using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GameHub.Utils
{
    public enum Graphic
    {
        [Display(Name = "DX10")]
        DX10 = 1,

        [Display(Name = "Nvidia GeForce GTX 780")]
        GTX780 = 2,

        [Display(Name = "AMD Radeon RX 470")]
        RadeonRx470 = 3,

        [Display(Name = "Nvidia GeForce RTX 2080 Ti")]
        RTX2080 = 4,

        [Display(Name = "AMD Radeon RX 6800 XT")]
        RadeonRx6800 = 5,
    }

    public static class GraphicValue
    {
        public static string GetGraphicValue(Graphic g)
        {
            FieldInfo fieldInfo = g.GetType().GetField(g.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            string gValue = displayAttribute?.Name ?? g.ToString();
            return gValue;
        }
    }
}
