using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Hishigata.Beatmaps;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModTrustworthy : Mod, IApplicableToBeatmapConverter
    {
        public override string Name => "Trustworthy";
        public override string Acronym => "TW";
        public override LocalisableString Description => HishigataModTrustworthyStrings.ModDescription;
        public override double ScoreMultiplier => 0.8;
        public override ModType Type => ModType.Conversion;
        public override IconUsage? Icon => FontAwesome.Solid.Check;

        public void ApplyToBeatmapConverter(IBeatmapConverter beatmapConverter)
        {
            var converter = (HishigataBeatmapConverter)beatmapConverter;
            converter.FeignsAllowed = false;
        }
    }
}
