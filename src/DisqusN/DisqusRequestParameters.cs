using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using LanguageExt;

namespace DisqusN
{
    public abstract class DisqusRequestParameters
    {
        protected StringBuilder appendPropertyValue<T>(string parameterName, Option<T> optionalValue, StringBuilder builder)
        {
            optionalValue.Match(
                Some: v => appendPropertyValue(parameterName, v, builder),
                None: () => { }
                );

            return builder;
        }

        protected StringBuilder appendPropertyValue<T>(string parameterName, T value, StringBuilder builder)
        {
            builder = appendPropertyNameAndEquals(parameterName, builder);
            var val = getValueForAppending(typeof (T), value);
            builder.Append(val);

            return builder;
        }

        protected StringBuilder appendPropertyValue<T>(string parameterName, Option<IEnumerable<T>> optionalValueArray, StringBuilder builder)
        {
            optionalValueArray.Match(
                Some: v => appendPropertyValue(parameterName, v, builder),
                None: () => { }
                );

            return builder;
        }

        protected StringBuilder appendPropertyValue<T>(string parameterName, IEnumerable<T> values, StringBuilder builder)
        {
            foreach (var value in values)
            {
                builder = appendPropertyNameAndEquals(parameterName, builder);
                var val = getValueForAppending(typeof(T), value);
                builder.Append(val);
            }

            return builder;
        }

        protected StringBuilder appendPropertyValue<T>(string parameterName, Option<T[]> optionalValueArray, StringBuilder builder)
        {
            optionalValueArray.Match(
                Some: v => appendPropertyValue(parameterName, v, builder),
                None: () => { }
                );

            return builder;
        }

        protected StringBuilder appendPropertyValue<T>(string parameterName, T[] values, StringBuilder builder)
        {
            foreach (var value in values)
            {
                builder = appendPropertyNameAndEquals(parameterName, builder);
                var val = getValueForAppending(typeof(T), value);
                builder.Append(val);
            }

            return builder;
        }

        private StringBuilder appendPropertyNameAndEquals(string parameterName, StringBuilder builder)
        {
            if (builder.Length > 0)
                builder.Append("&");

            builder.Append(parameterName);
            builder.Append("=");
            return builder;
        }

        private string toInvariantString(object obj)
        {
            var convertible = obj as IConvertible;

            if (convertible != null)
                return convertible.ToString(CultureInfo.InvariantCulture);

            var formattable = obj as IFormattable;

            if (formattable != null)
                return formattable.ToString(null, CultureInfo.InvariantCulture);

            return obj.ToString();
        }

        private string getValueForAppending(Type valueType, object originalValue)
        {
            if (originalValue is DateTime)
            {
                var date = (DateTime) originalValue;
                return date.ToString("O");
            }
            else if (originalValue.GetType().IsEnum)
            {
                // Use description on enum
                var name = Enum.GetName(valueType, originalValue);
                
                FieldInfo objInfo = valueType.GetField(name);

                DescriptionAttribute descriptionAttribute = objInfo.GetCustomAttribute<DescriptionAttribute>(false);
                return descriptionAttribute.Description;
            }
            else
            {
                return toInvariantString(originalValue);
            }
        }

        public string GetResourceUriQuery()
        {
            var props = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            StringBuilder builder = new StringBuilder();

            foreach (var prop in props)
            {
                var attrib = (DisqusParameterAttribute)Attribute.GetCustomAttribute(prop, typeof (DisqusParameterAttribute));

                if (attrib == null)
                {
                    continue;
                }

                // Use dynamic dispatch to call correct method
                // Slower, but cuts down on code writing in derived classes...
                var propValue = (dynamic)prop.GetValue(this);
                appendPropertyValue(attrib.ParameterName, propValue, builder);
            }

            return builder.ToString();
        }
    }
}