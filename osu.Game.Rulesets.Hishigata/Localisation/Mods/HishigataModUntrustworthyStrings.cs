using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation.Mods
{
    public static class HishigataModUntrustworthyStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.Mods.HishigataModUntrustworthyStrings";

        /// <summary>
        /// "All notes switch sides."
        /// </summary>
        public static LocalisableString ModDescription => new TranslatableString(getKey(@"mod_description"), @"All notes switch sides.");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
