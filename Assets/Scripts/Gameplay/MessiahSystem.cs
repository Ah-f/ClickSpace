namespace ClickSpace.Messiah.Gameplay
{
    public sealed class MessiahProfile
    {
        public float PropagationMultiplier { get; set; } = 1f;
        public float CharismaMultiplier { get; set; } = 1f;
        public float TrustBonus { get; set; }
        public float StabilityBonus { get; set; }
    }

    public static class MessiahSystem
    {
        public static MessiahProfile GetProfile(string messiahId)
        {
            return messiahId switch
            {
                "M01" => new MessiahProfile { PropagationMultiplier = 1.00f, CharismaMultiplier = 1.08f, TrustBonus = 0.18f, StabilityBonus = 0.22f },
                "M02" => new MessiahProfile { PropagationMultiplier = 1.18f, CharismaMultiplier = 1.05f, TrustBonus = -0.10f, StabilityBonus = -0.08f },
                "M03" => new MessiahProfile { PropagationMultiplier = 1.06f, CharismaMultiplier = 1.10f, TrustBonus = -0.12f, StabilityBonus = 0.20f },
                "M04" => new MessiahProfile { PropagationMultiplier = 1.14f, CharismaMultiplier = 1.04f, TrustBonus = 0.05f, StabilityBonus = 0.08f },
                "M05" => new MessiahProfile { PropagationMultiplier = 0.94f, CharismaMultiplier = 0.98f, TrustBonus = 0.12f, StabilityBonus = 0.26f },
                "M06" => new MessiahProfile { PropagationMultiplier = 1.25f, CharismaMultiplier = 1.20f, TrustBonus = -0.20f, StabilityBonus = -0.18f },
                _ => new MessiahProfile(),
            };
        }
    }
}
