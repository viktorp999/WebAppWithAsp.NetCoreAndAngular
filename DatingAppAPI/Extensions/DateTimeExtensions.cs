
namespace DatingAppAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dateonly)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var age = today.Year - dateonly.Year;

            if (dateonly > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
