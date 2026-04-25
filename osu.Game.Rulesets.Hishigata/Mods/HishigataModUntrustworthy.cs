using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Hishigata.Objects;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModUntrustworthy : Mod, IApplicableToHitObject
    {
        public override string Name => "Untrustworthy";
        public override string Acronym => "UW";
        public override LocalisableString Description => HishigataModUntrustworthyStrings.ModDescription;
        public override double ScoreMultiplier => 0.8;
        public override ModType Type => ModType.Conversion;
        public override IconUsage? Icon => FontAwesome.Solid.Exclamation;
        public override Type[] IncompatibleMods => new[] { typeof(HishigataModTrustworthy), typeof(HishigataModInvert) };

        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is HishigataNote hishigataNote) hishigataNote.IsFeign = true;
        }
    }
}
