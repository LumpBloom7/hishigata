using System;

namespace osu.Game.Rulesets.Hishigata
{
    public static class HishigataExtensions
    {
        public static float ToAngle(this HishigataAction direction) => (int)direction * 90;

        public static bool IsOppositeTo(this HishigataAction direction, HishigataAction other) => Math.Abs(direction - other) == 2;
    }
}
