using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation.Mods
{
    public static class HishigataModHiddenStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.Mods.HishigataModHiddenStrings";

        /// <summary>
        /// "Notes fade out just before you hit them."
        /// </summary>
        public static LocalisableString ModDescription => new TranslatableString(getKey(@"mod_description"), @"Notes fade out just before you hit them.");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
