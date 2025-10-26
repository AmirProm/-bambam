namespace api.Models.Errors;

public class ApiException
{
    public ObjectId Id { get; init; }
    required public int StatusCode { get; set; }
    required public string? Message { get; set; }
    required public string? Details { get; set; }
    required public DateTime Time { get; set; }    
};
