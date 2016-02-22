using System;
using System.IO;
using LanguageExt;
using Newtonsoft.Json;
using static LanguageExt.Prelude;

namespace DisqusN.Resources.Forums
{
    public sealed class ForumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Either<string, Forum> either = new Either<string, Forum>();

            // String for just forum name
            // Object for full Forum object

            if (reader.TokenType == JsonToken.String)
            {
                string forumName = reader.Value.ToString();
                either = Left<string, Forum>(forumName);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                Forum forum = (Forum)serializer.Deserialize(reader, typeof(Forum));
                either = Right<string, Forum>(forum);
            }
            else
            {
                throw new InvalidDataException("Unknown data format within ForumConverter");
            }

            return either;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
