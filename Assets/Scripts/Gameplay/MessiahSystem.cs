namespace ClickSpace.Messiah.Gameplay
{
    public static class MessiahSystem
    {
        public static float GetPropagationMultiplier(string messiahId)
        {
            return messiahId switch
            {
                "M02" => 1.18f,
                "M06" => 1.25f,
                _ => 1.0f,
            };
        }
    }
}
