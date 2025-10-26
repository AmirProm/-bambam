namespace api.Extensions.Validations;

/// <summary>
/// Set a minimum and maximum size for input files.
/// </summary>
/// <param name="minFileSize"></param>
/// <param name="maxFileSize"></param>
public class FileSizeAttribute(long minFileSize, long maxFileSize) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
            if (file.Length < minFileSize)
            {
                return new ValidationResult($"The file is {file.Length / 1_000}KB which is below the allowed minimum size of {minFileSize / 1_000} kilobytes.");
            }
            else if (file.Length > maxFileSize)
            {
                return new ValidationResult($"The file is {file.Length / 1_000}KB which is over the allowed maximum size of {maxFileSize / 1_000_000} megabytes.");
            }

        return ValidationResult.Success;
    }
}