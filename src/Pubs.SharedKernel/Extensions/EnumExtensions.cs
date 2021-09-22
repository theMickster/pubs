using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;


namespace Pubs.SharedKernel.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// When you have applied the attribute Desciption
        /// to a specific enum, this will allow you to output
        /// that. It will default to just outputting the value
        /// if the attribute is not present.
        /// Caution-http://stackoverflow.com/a/1415187/1248536 < Caution-http://stackoverflow.com/a/1415187/1248536 > 
        /// See AssertType for an example of how how it is
        /// being used.
        /// 
        /// I would also warn if the plan is to use this in massive loops 
        /// Since it is using reflecation, you should shy away from using this.
        /// Instead implement a specific extension for you enumType 
        /// Caution-http://stackoverflow.com/a/1415460/1248536 < Caution-http://stackoverflow.com/a/1415460/1248536 > 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Description from attribute</returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }

        /// <summary>
        /// Gets the display name attribute for the specified enum (if one exists), otherwise the enum 
        /// is simply converted to a string.
        /// </summary>
        /// <param name="@enum">The @enum.</param>
        /// <returns>System.String.</returns>
        public static string GetDisplayName(this Enum @enum)
        {
            Type enumType = @enum.GetType();
            MemberInfo[] memberInfo = enumType.GetMember(@enum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _displayNameAttribute = memberInfo.First().GetCustomAttribute<DisplayAttribute>();
                if (_displayNameAttribute != null)
                    return _displayNameAttribute.Name;
            }

            return @enum.ToString();
        }
    }
}
