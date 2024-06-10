using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProjectManagementSystem.Domain.Helpers
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();

            return attribute?.GetName();
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute => enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>() ?? throw new ArgumentNullException($"Аттрибут {nameof(TAttribute)} не найден");
    }
}
