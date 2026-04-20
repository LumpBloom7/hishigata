using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Graphics;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Hishigata.Objects;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModInvert : Mod, IApplicableToHitObject
    {
        public override string Name => "Invert";
        public override string Acronym => "IN";
        public override LocalisableString Description => HishigataModInvertStrings.ModDescription;
        public override double ScoreMultiplier => 1.0;
        public override ModType Type => ModType.Fun;
        public override Type[] IncompatibleMods => new[] { typeof(HishigataModTrustworthy) };
        public override IconUsage? Icon => OsuIcon.ModInvert;

        public void ApplyToHitObject(HitObject hitObject)
        {
            var hishigataHitObject = (HishigataHitObject)hitObject;
            if (hishigataHitObject is HishigataNote hishigataNote) hishigataNote.IsFeign = !hishigataNote.IsFeign;
        }
    }
}
