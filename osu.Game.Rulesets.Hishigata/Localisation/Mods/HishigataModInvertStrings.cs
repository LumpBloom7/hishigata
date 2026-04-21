using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation.Mods
{
    public static class HishigataModInvertStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.Mods.HishigataModInvertStrings";

        /// <summary>
        /// "Regular notes and feigns are swapped."
        /// </summary>
        public static LocalisableString ModDescription => new TranslatableString(getKey(@"mod_description"), @"Regular notes and feigns are swapped.");

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
