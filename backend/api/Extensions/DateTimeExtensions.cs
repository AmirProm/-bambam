namespace api.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);

        int age = today.Year - dob.Year;

        if (dob > today.AddYears(-age))
            age--;

        return age;
    }
}
