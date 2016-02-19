using System;
using System.IO;
using LanguageExt;
using Newtonsoft.Json;
using static LanguageExt.Prelude;

namespace DisqusN.Core.Resources.Forums
{
    public sealed class AuthorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Either<long, Author> either = new Either<long, Author>();

            // String for just author id
            // Object for full Author object

            if (reader.TokenType == JsonToken.String)
            {
                long authorId;
                if (long.TryParse(reader.Value.ToString(), out authorId))
                {
                    either = Left<long, Author>(authorId);
                }
                else
                {
                    throw new InvalidDataException("Could not parse authorId");
                }
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                Author author = (Author) serializer.Deserialize(reader, typeof (Author));
                either = Right<long, Author>(author);
            }
            else
            {
                throw new InvalidDataException("Unknown data format within AuthorConverter");
            }

            return either;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
