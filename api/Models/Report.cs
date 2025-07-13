namespace api.Models;

public record Report
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string? Id,
    ObjectId ReportId,
    string Type,
    ObjectId TargetId,
    string Reason,//  دلیل گزارش
    DateTime CreatedAt
);
