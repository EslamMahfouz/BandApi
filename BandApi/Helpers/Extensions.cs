using System;

namespace BandApi.Helpers
{
    public static class Extensions
    {
        public static int GetYearsAgo(this DateTime date)
        {
            return DateTime.Now.Year - date.Year;
        }
    }
}
