using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace AsmrsBackend.Data
{
    public class StringOrIntSerializer : SerializerBase<string>
    {
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonType = context.Reader.CurrentBsonType;

            return bsonType switch
            {
                BsonType.String => context.Reader.ReadString(),
                BsonType.Int32 => context.Reader.ReadInt32().ToString(),
                _ => throw new BsonSerializationException($"Cannot deserialize BsonType {bsonType} to a string.")
            };
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
        {
            if (value == null)
            {
                context.Writer.WriteNull();
            }
            else
            {
                context.Writer.WriteString(value);
            }
        }
    }
}
