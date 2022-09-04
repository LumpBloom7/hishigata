using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation
{
    public static class HishigataActionStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.HishigataActionStrings";

        /// <summary>
        /// "Up"
        /// </summary>
        public static LocalisableString Up => new TranslatableString(getKey("up"), "Up");

        /// <summary>
        /// "Down"
        /// </summary>
        public static LocalisableString Down => new TranslatableString(getKey("down"), "Down");

        /// <summary>
        /// "Left"
        /// </summary>
        public static LocalisableString Left => new TranslatableString(getKey("left"), "Left");

        /// <summary>
        /// "Right"
        /// </summary>
        public static LocalisableString Right => new TranslatableString(getKey("right"), "Right");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
