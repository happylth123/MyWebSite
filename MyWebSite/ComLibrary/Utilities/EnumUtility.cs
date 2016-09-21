using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealNext.Infrastructure.Utilities
{
    /// <summary>
    /// Enum utility
    /// </summary>
    public static class EnumUtility
    {
        /// <summary>
        /// Safe parse
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum? SafeParse<TEnum>(string value) where TEnum : struct
        {
            TEnum @enum;

            if (!Enum.TryParse(value, out @enum))
            {
                return null;
            }

            return @enum;
        }

        /// <summary>
        /// Safe parse
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum? SafeParse<TEnum>(Enum value) where TEnum : struct
        {
            return SafeParse<TEnum>(value.ToString());
        }

        /// <summary>
        /// Safe parse
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultEnumValue"></param>
        /// <returns></returns>
        public static TEnum SafeParse<TEnum>(string value, TEnum defaultEnumValue) where TEnum : struct
        {
            TEnum @enum;

            if (!Enum.TryParse(value, out @enum))
            {
                @enum = defaultEnumValue;
            }

            return @enum;
        }

        /// <summary>
        /// Safe parse
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultEnumValue"></param>
        /// <returns></returns>
        public static TEnum SafeParse<TEnum>(Enum value, TEnum defaultEnumValue) where TEnum : struct
        {
            return SafeParse<TEnum>(value.ToString(), defaultEnumValue);
        }

        /// <summary>
        /// GetDisplayName
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescriptionName(this Enum @enum)
        {
            Type enumType = @enum.GetType();

            string nameOfEnum = Enum.GetName(enumType, @enum);
            if (!String.IsNullOrEmpty(nameOfEnum))
            {
                FieldInfo field = enumType.GetField(nameOfEnum);
                if (field != null)
                {
                    DescriptionAttribute displayAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (displayAttribute != null)
                    {
                        return displayAttribute.Description;
                    }
                }
            }

            return nameOfEnum;
        }
    }
}