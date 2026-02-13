namespace ClickSpace.Messiah.Core
{
    public static class ResourceSystem
    {
        public static void ApplyTickGains(RunState state, float faithDelta, float fundDelta)
        {
            state.Faith += faithDelta;
            state.Fund += fundDelta;
        }
    }
}
