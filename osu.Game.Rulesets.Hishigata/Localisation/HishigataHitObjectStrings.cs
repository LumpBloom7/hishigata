using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation
{
    public static class HishigataHitObjectStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.HishigataHitObjectStrings";

        /// <summary>
        /// "Note"
        /// </summary>
        public static LocalisableString Note => new TranslatableString(getKey(@"note"), @"Note");

        /// <summary>
        /// "Feign"
        /// </summary>
        public static LocalisableString Feign => new TranslatableString(getKey(@"feign"), @"Feign");

        /// <summary>
        /// "Bonus"
        /// </summary>
        public static LocalisableString Bonus => new TranslatableString(getKey(@"bonus"), @"Bonus");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
