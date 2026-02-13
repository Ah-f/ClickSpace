namespace ClickSpace.Messiah.Gameplay
{
    public static class EndingSystem
    {
        public static string ResolveEnding(int followers, float trust, float miracleSuccess, float stability, bool apocalypseBlocked)
        {
            if (apocalypseBlocked && miracleSuccess >= 60f && stability >= 65f) return "ApocalypseBlocked";
            if (followers >= 14000 && trust >= 70f) return "MassSalvation";
            if (followers >= 16000 && trust >= 50f) return "Dominion";
            if (followers >= 10000 && trust < 45f) return "Corrupted";
            return "Unfinished";
        }
    }
}
