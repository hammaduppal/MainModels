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
     "🌄 The world sleeps, but dreams awaken—good morning, early riser.",
    "🌅 The quiet of dawn is your secret advantage—use it well.",
    "☕ The calm before sunrise brings clarity—plan your best moves now.",
    "🌤️ Early hours, empty streets, endless possibilities.",
    "🕊️ Peace lives in these still moments before the world stirs.",
    "💡 Great ideas are born when the world is silent—good morning.",
    "🌙 The stars fade, but your goals still shine—keep moving.",
    "🌻 The early light whispers: today is yours to shape.",
    "✨ Before the sun climbs, greatness begins quietly.",
    "🎯 The disciplined wake early—every minute before sunrise counts.",
    "🌞 The first light isn’t just for the sky—it’s for your spirit too.",
    "📖 Mornings this early are made for reflection and purpose.",
    "🌺 The air feels pure, the mind feels sharp—start strong.",
    "🌈 While others dream, you’re preparing to live your dream.",
    "🚀 Early starts lead to quiet victories—this is your moment."
};

            return PickRandom(messages);
        }

        private static string GetMorningMessage()
        {
            var messages = new List<string>
            {
            "☀️ Good Morning! Wishing you a productive day.",
            "🌻 Morning vibes—let’s make today amazing!",
            "💪 Start strong, the day is yours to conquer.",
            "🌞 Rise and shine! A new day means new chances.",
            "🌈 Keep smiling—today’s going to be a great one!",
            "☕ Fresh coffee, fresh mindset, fresh goals!",
            "🔥 Wake up with purpose, and chase your dreams!",
            "🌼 Good morning! Be kind, stay focused, and do great things.",
            "✨ Every sunrise brings an opportunity to begin again.",
            "🚀 You’ve got this! Let today be your success story.",
            "🌤️ New day, new energy, same determination.",
            "🌺 Good morning—believe in yourself and make it happen!",
            "💫 Let positivity be your power today.",
            "🌅 Another day, another reason to shine bright!",
            "📈 Small steps this morning lead to big wins later."
        };

            return PickRandom(messages);
        }

        private static string GetNoonMessage()
        {
            var messages = new List<string>
        {
           "🌞 It's Noon—time to recharge with some energy!",
            "🍴 Midday is here, don’t forget to refuel.",
            "✨ Half the day done, half to go—keep it up!",
            "☀️ Take a deep breath—you’re doing great so far!",
            "🥗 Lunch break vibes—refresh your mind and body.",
            "🌻 The sun’s high, and so should your motivation be!",
            "🚀 Midday check-in—stay focused and finish strong!",
            "💡 Great progress so far, keep your momentum going!",
            "☕ A little break now will fuel your afternoon hustle.",
            "🌤️ You’ve conquered the morning—now own the afternoon!",
            "🌼 Smile! You’re halfway through a successful day.",
            "🔥 Stay positive, stay sharp—your goals need your energy.",
            "🕛 Noon reminds us: pace yourself, the day’s still young.",
            "🌈 Keep the vibes high and productivity higher!",
            "💪 Refocus, refuel, and rise stronger for the rest of the day."
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
          "🌤️ Good Afternoon! Keep your focus—you're doing amazing.",
    "☕ A little coffee and a lot of determination go a long way!",
    "🌞 The day’s not over yet—finish strong!",
    "💪 Push through the afternoon, success is waiting at the finish line.",
    "🌻 Stay positive and productive—the best is yet to come!",
    "🚀 Keep your energy up, you’re closer to your goals than you think.",
    "🍀 A great afternoon leads to a great evening—stay motivated!",
    "🌈 Keep the momentum going, you’ve come so far already!",
    "🔥 Afternoon hustle sets up your evening success!",
    "🌺 Don’t slow down now—your hard work is paying off!",
    "💡 A short break can refresh your mind for the rest of the day.",
    "🌼 Stay calm, stay focused—the day is still yours to win.",
    "📈 Progress might be slow, but it’s still progress—keep at it!",
    "☀️ The afternoon sun shines bright—so should your motivation.",
    "✨ Every small step this afternoon counts toward your big dreams."
        };
            return PickRandom(messages);
        }

        private static string GetEveningMessage()
        {
            var messages = new List<string>
        {
            "🌇 Good Evening! Hope you had a fulfilling day.",
            "🌙 Evening peace—time to unwind and reflect.",
            "🎯 A great day deserves a calm evening.",
            "🌇 Good Evening! Take a moment to appreciate your day’s efforts.",
            "🌅 The sun sets, but your achievements shine on!",
            "☕ Relax and unwind—you’ve earned this peace.",
            "🌻 Evening is here—breathe, smile, and let go of the day’s stress.",
            "✨ Reflect on your wins, no matter how small—they matter!",
            "🌤️ Slow down, recharge, and prepare for a better tomorrow.",
            "🌙 A peaceful evening leads to a powerful tomorrow.",
            "💫 Let gratitude fill your heart this evening.",
            "🌼 You’ve done your best—now it’s time to rest and refresh.",
            "🌈 The day may end, but your dreams continue to grow.",
            "🔥 Keep your spirit high—tomorrow’s another chance to shine!",
            "🌺 Evening vibes: calm mind, full heart, peaceful soul.",
            "📖 Every sunset brings a new chapter—write it with gratitude.",
            "🕯️ As the night approaches, let peace replace pressure.",
            "💖 End your day with positivity and pride—you’ve come far!"
        };
            return PickRandom(messages);
        }

        private static string GetNightMessage()
        {
            var messages = new List<string>
        {
            "🌙 The day winds down—time to relax and reflect.",
            "😌 Late evening is perfect for slowing down.",
            "📖 A quiet night is great for learning and growth.",
             "🌙 Good Night! Time to rest and recharge for a new day ahead.",
            "😴 Let go of the worries—tomorrow is full of new possibilities.",
            "✨ The stars are shining just for you—sleep peacefully.",
            "🌌 A calm mind and a grateful heart make the best bedtime.",
            "💤 Close your eyes, breathe deep, and drift into sweet dreams.",
            "🌠 Every day may not be perfect, but every night brings peace.",
            "🕯️ Rest easy—tomorrow is another chance to shine.",
            "🌺 Good night! You did your best today, and that’s enough.",
            "🌤️ The day ends, but your dreams are just beginning.",
            "💖 Sleep well knowing you’ve grown a little more today.",
            "🌻 Good night—may your dreams be bright and your rest deep.",
            "🌙 Time to pause, reflect, and let your soul recharge.",
            "🌟 End the day with gratitude, and wake up with purpose.",
            "🍃 Let peace fill your heart as the night wraps around you.",
            "💫 Good night—rest now, tomorrow is waiting for your magic."
        };
            return PickRandom(messages);
        }

        private static string GetMidnightMessage()
        {
            var messages = new List<string>
        {
            "🌌 Burning the midnight oil? Stay focused and take care.",
            "🌠 Midnight thoughts lead to morning success.",
            "😴 Don’t forget to rest—tomorrow needs your energy.",
              "🌙 Midnight thoughts: stay calm, stay hopeful, tomorrow awaits.",
            "🌌 The world sleeps, but your dreams stay awake—keep believing.",
            "🕛 It’s late, but your peace of mind matters more than the clock.",
            "✨ Midnight reminds us—it’s never too late to start fresh.",
            "💤 Rest if you must, but never stop believing in yourself.",
            "🌠 The night is silent, but your goals still whisper—keep them close.",
            "🕯️ A peaceful heart makes even the darkest night beautiful.",
            "🌺 Sometimes, quiet nights bring the loudest clarity.",
            "🌃 You made it through the day—be proud, rest easy now.",
            "💫 Midnight isn’t the end—it’s the bridge to a new beginning.",
            "🌻 Even stars need the dark to shine—so do you.",
            "🌒 Take a breath, let go of the noise, and just be still.",
            "🌈 The world rests, and so should you—tomorrow needs your light.",
            "☕ If you’re still awake, make this moment peaceful and meaningful.",
            "🕊️ Late nights are for calm hearts and gentle thoughts."
        };
            return PickRandom(messages);
        }

        private static string GetPreDawnMessage()
        {
            var messages = new List<string>
        {
            "🌠 Still awake? A new day is just around the corner.",
            "🌌 Quiet hours—perfect for deep thinking.",
            "✨ The early hours belong to dreamers and doers." ,
             "🌄 The world is still, but your spirit awakens—good pre-dawn!",
            "🌙 Before the sun rises, the most peaceful thoughts are born.",
            "🕓 The quiet before dawn holds endless inspiration—listen closely.",
            "✨ The sky is dark, but your purpose already shines.",
            "🌌 Great days begin long before the world wakes up.",
            "💫 Early hours, clear mind—perfect time to dream and plan.",
            "🕯️ The calm of pre-dawn is a gift—use it to find your focus.",
            "🌠 While others rest, you prepare—this is how success starts.",
            "🌺 Breathe deeply, think clearly, and let purpose guide your dawn.",
            "🌤️ The first light is near—get ready to rise with it.",
            "☕ A peaceful start before sunrise brings strength for the day ahead.",
            "🌈 Stillness of dawn reminds you: new beginnings are coming.",
            "📖 Pre-dawn moments are made for reflection and quiet growth.",
            "🌻 Wake gently—each moment before sunrise carries potential.",
            "🕊️ Silence, serenity, and strength—the true beauty of pre-dawn."
        };
            return PickRandom(messages);
        }

        private static string PickRandom(List<string> messages)
        {
            return messages[_random.Next(messages.Count)];
        }
    }

}
