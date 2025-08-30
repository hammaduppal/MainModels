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
        //public static string GetGreeting()
        //{
        //    int hour = DateTime.Now.Hour;

        //    if (hour >= 4 && hour < 6)
        //        return "🌄 A fresh start to the day—rise and shine!";
        //    else if (hour >= 6 && hour < 12)
        //        return "☀️ Good Morning! Wishing you a productive day.";
        //    else if (hour >= 12 && hour < 13)
        //        return "🌞 It's Noon—time to recharge with some energy!";
        //    else if (hour >= 13 && hour < 16)
        //        return "🌤️ Good Afternoon! Keep up the great work.";
        //    else if (hour >= 16 && hour < 18)
        //        return "🌆 Wrapping up strong—you're almost there!";
        //    else if (hour >= 18 && hour < 21)
        //        return "🌇 Good Evening! Hope you had a fulfilling day.";
        //    else if (hour >= 21 && hour < 23)
        //        return "🌙 The day winds down—time to relax and reflect.";
        //    else if (hour >= 23 || hour < 2)
        //        return "🌌 Burning the midnight oil? Stay focused and take care.";
        //    else // 2 AM – 4 AM
        //        return "🌠 Still awake? A new day is just around the corner.";
        //}


    }
    public static class GreetingHelper
    {
        private static readonly Random _random = new Random();

        public static string GetGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 4 && hour < 6)
                return GetEarlyMorningMessage();
            else if (hour >= 6 && hour < 12)
                return GetMorningMessage();
            else if (hour >= 12 && hour < 13)
                return GetNoonMessage();
            else if (hour >= 13 && hour < 16)
                return GetAfternoonMessage();
            else if (hour >= 16 && hour < 18)
                return GetLateAfternoonMessage();
            else if (hour >= 18 && hour < 21)
                return GetEveningMessage();
            else if (hour >= 21 && hour < 23)
                return GetNightMessage();
            else if (hour >= 23 || hour < 2)
                return GetMidnightMessage();
            else // 2 AM – 4 AM
                return GetPreDawnMessage();
        }

        private static string GetEarlyMorningMessage()
        {
            var messages = new List<string>
        {
            "🌄 A fresh start to the day—rise and shine!",
            "💡 Early mornings bring new opportunities.",
            "🌅 The world is quiet—perfect time to plan big."
        };
            return PickRandom(messages);
        }

        private static string GetMorningMessage()
        {
            var messages = new List<string>
        {
            "☀️ Good Morning! Wishing you a productive day.",
            "🌻 Morning vibes—let’s make today amazing!",
            "💪 Start strong, the day is yours to conquer."
        };
            return PickRandom(messages);
        }

        private static string GetNoonMessage()
        {
            var messages = new List<string>
        {
            "🌞 It's Noon—time to recharge with some energy!",
            "🍴 Midday is here, don’t forget to refuel.",
            "✨ Half the day done, half to go—keep it up!"
        };
            return PickRandom(messages);
        }

        private static string GetAfternoonMessage()
        {
            var messages = new List<string>
        {
            "🌤️ Good Afternoon! Keep up the great work.",
            "🚀 Afternoon energy—push through to success!",
            "🔥 Stay focused, you’re doing amazing."
        };
            return PickRandom(messages);
        }

        private static string GetLateAfternoonMessage()
        {
            var messages = new List<string>
        {
            "🌆 Wrapping up strong—you're almost there!",
            "🌞 Late afternoon glow—time to finish well.",
            "✨ The day’s end is near, stay motivated!"
        };
            return PickRandom(messages);
        }

        private static string GetEveningMessage()
        {
            var messages = new List<string>
        {
            "🌇 Good Evening! Hope you had a fulfilling day.",
            "🌙 Evening peace—time to unwind and reflect.",
            "🎯 A great day deserves a calm evening."
        };
            return PickRandom(messages);
        }

        private static string GetNightMessage()
        {
            var messages = new List<string>
        {
            "🌙 The day winds down—time to relax and reflect.",
            "😌 Late evening is perfect for slowing down.",
            "📖 A quiet night is great for learning and growth."
        };
            return PickRandom(messages);
        }

        private static string GetMidnightMessage()
        {
            var messages = new List<string>
        {
            "🌌 Burning the midnight oil? Stay focused and take care.",
            "🌠 Midnight thoughts lead to morning success.",
            "😴 Don’t forget to rest—tomorrow needs your energy."
        };
            return PickRandom(messages);
        }

        private static string GetPreDawnMessage()
        {
            var messages = new List<string>
        {
            "🌠 Still awake? A new day is just around the corner.",
            "🌌 Quiet hours—perfect for deep thinking.",
            "✨ The early hours belong to dreamers and doers."
        };
            return PickRandom(messages);
        }

        private static string PickRandom(List<string> messages)
        {
            return messages[_random.Next(messages.Count)];
        }
    }

}
