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
        //Current Mod Icon is a check mark, however looks ugly and does not match other Icons,
        // so needs updating. Perhaps making it smaller somehow would be enough?
        //public override IconUsage? Icon => FontAwesome.Solid.Check;

        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is HishigataNote hishigataNote) hishigataNote.IsFeign = false;
        }
    }
}
