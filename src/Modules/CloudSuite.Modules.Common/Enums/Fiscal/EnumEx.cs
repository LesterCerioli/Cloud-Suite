using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CloudSuite.Modules.Common.Enums.Fiscal
{
    public static class EnumExtensions
    {
        public static string[] GetEnumDescriptions<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            return EnumDescriptionHelper.GetDescriptions(value);
        }

        public static string GetEnumDescription<TEnum>(this TEnum value)
            where TEnum : Enum
        {
            return string.Join(", ", GetEnumDescriptions(value));
        }

        public static string GetEnumDescription<TEnum>(this TEnum value, params object[] args)
            where TEnum : Enum
        {
            var description = GetEnumDescription(value);
            return string.Format(description, args);
        }

        public static TEnum GetEnumValueFromDescription<TEnum>(string description)
            where TEnum : Enum
        {
            return EnumDescriptionHelper.GetValueFromDescription<TEnum>(description);
        }
    }

    internal static class EnumDescriptionHelper
    {
        private static Type TypeOfDescriptionAttribute = typeof(DescriptionAttribute);
        private static Type TypeOfFlagsAttribute = typeof(FlagsAttribute);

        public static string[] GetDescriptions<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var items = new List<TEnum>();

            var typeOfValue = value.GetType();
            if (typeOfValue.IsDefined(TypeOfFlagsAttribute, false))
            {
                if (Convert.ToUInt64(value) == 0)
                    return new[] { GetDescriptionItem(value) };

                foreach (TEnum enumValue in Enum.GetValues(typeOfValue))
                {
                    if (value.HasFlag(enumValue) && Convert.ToUInt64(enumValue) != 0)
                    {
                        items.Add(enumValue);
                    }
                }
            }
            else
            {
                items.Add(value);
            }

            return items.Select(GetDescriptionItem).ToArray();
        }

        public static string GetDescription<TEnum>(TEnum value)
            where TEnum : Enum
        {
            return string.Join(", ", GetDescriptions(value));
        }

        public static TEnum GetValueFromDescription<TEnum>(string description)
            where TEnum : Enum
        {
            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                var attribute = GetDescriptionAttribute(enumValue);
                if (attribute != null && attribute.Description == description)
                {
                    return enumValue;
                }

                if (enumValue.ToString() == description)
                {
                    return enumValue;
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }

        private static DescriptionAttribute GetDescriptionAttribute<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var field = value.GetType().GetField(value.ToString());
            return (DescriptionAttribute)Attribute.GetCustomAttribute(field, TypeOfDescriptionAttribute);
        }

        private static string GetDescriptionItem<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var attribute = GetDescriptionAttribute(value);
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}