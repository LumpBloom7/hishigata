using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Hishigata.Objects;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModTrustworthy : Mod, IApplicableToHitObject
    {
        public override string Name => "Trustworthy";
        public override string Acronym => "TW";
        public override LocalisableString Description => HishigataModTrustworthyStrings.ModDescription;
        public override double ScoreMultiplier => 0.8;
        public override ModType Type => ModType.Conversion;
        public override Type[] IncompatibleMods => new[] { typeof(HishigataModInvert) };
        public override IconUsage? Icon => FontAwesome.Solid.Check;

        public void ApplyToHitObject(HitObject hitObject)
        {
            HishigataHitObject hishigataHitObject = (HishigataHitObject)hitObject;
            if (hishigataHitObject is HishigataNote hishigataNote) hishigataNote.IsFeign = false;
        }
    }
}
