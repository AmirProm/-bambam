using DnsClient;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Room
(
  [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    string Name,
    bool IsPrivate,
    ObjectId Members, //  یا به صورت ابجکت یا ارایی ستفاده میکنیم سوال؟؟
    DateTime CreatedAt
);
