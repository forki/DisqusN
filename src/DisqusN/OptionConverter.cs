using System;
using System.Diagnostics;
using LanguageExt;
using Newtonsoft.Json;

namespace DisqusN
{
    public class OptionConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            T val = readValue(reader);
            Option<T> option = Option<T>.Some(val);
            return option;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        private T readValue(JsonReader reader)
        {
            Debug.Assert(typeof(T)==reader.ValueType);
            T val = (T)reader.Value;
            return val;
        }
    }
}
