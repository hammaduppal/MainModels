namespace MainModels.Util
{
    public static class TimeHelper
    {
        public static string GetFormattedTimeSpan(DateTime createdOn)
        {
            var res = DateTime.Now - createdOn;

            if (res.TotalMinutes < 5)
            {
                return "Just Now";
            }
            else if (res.TotalMinutes < 60)
            {
                return $"{res.Minutes} minutes ago";
            }
            else if (res.TotalHours < 24)
            {
                return $"{res.Hours} hours ago";
            }
            else if (res.TotalDays < 7)
            {
                return $"{res.Days} days ago";
            }
            else
            {
                return createdOn.ToString("MMM dd, yyyy");
            }
        }
    }
}
