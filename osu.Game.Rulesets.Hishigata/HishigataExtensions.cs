using System;
using osuTK;

namespace osu.Game.Rulesets.Hishigata
{
    public static class HishigataExtensions
    {
        public static float ToAngle(this HishigataAction direction) => (int)direction * 90;

        public static bool IsOppositeTo(this HishigataAction direction, HishigataAction other) => Math.Abs(direction - other) == 2;

        public static float GetDegreesFromPosition(this Vector2 a, Vector2 b)
        {
            Vector2 direction = b - a;
            float angle = MathHelper.RadiansToDegrees(MathF.Atan2(direction.Y, direction.X));
            if (angle < 0f) angle += 360f;
            return angle + 90;
        }

        public static float GetDeltaAngle(float a, float b)
        {
            float x = b;
            float y = a;

            if (a > b)
            {
                x = a;
                y = b;
            }

            if (x - y < 180)
                x -= y;
            else
                x = 360 - x + y;

            return x;
        }
    }
}
