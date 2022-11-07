using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation.Mods
{
    public static class HishigataModTrustworthyStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.Mods.HishigataModTrustworthyStrings";

        /// <summary>
        /// "Notes don't switch sides."
        /// </summary>
        public static LocalisableString ModDescription => new TranslatableString(getKey(@"mod_description"), @"Notes don't switch sides.");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
