using System.Collections.Generic;

namespace ClickSpace.Messiah.Gameplay
{
    public static class DoctrineSystem
    {
        public static float GetDoctrinePower(IEnumerable<string> doctrineIds)
        {
            float power = 0f;
            foreach (var _ in doctrineIds)
            {
                power += 1f;
            }

            return power;
        }
    }
}
