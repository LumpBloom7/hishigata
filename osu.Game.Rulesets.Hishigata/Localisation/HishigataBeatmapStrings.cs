using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Hishigata.Localisation
{
    public static class HishigataBeatmapStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Hishigata.Resources.Localisation.HishigataBeatmapStrings";

        /// <summary>
        /// "Note count"
        /// </summary>
        public static LocalisableString NoteCount => ObjectCount(HishigataHitObjectStrings.Note);

        /// <summary>
        /// "Feign count"
        /// </summary>
        public static LocalisableString FeignCount => ObjectCount(HishigataHitObjectStrings.Feign);

        /// <summary>
        /// "Bonus count"
        /// </summary>
        public static LocalisableString BonusCount => ObjectCount(HishigataHitObjectStrings.Bonus);

        /// <summary>
        /// "{0} Count"
        /// </summary>
        private static LocalisableString ObjectCount(LocalisableString hitObjectName) => new TranslatableString(getKey(@"#_count"), @"{0} count", hitObjectName);

        private static string getKey(string key) => $"{prefix}:{key}";
    }
}
