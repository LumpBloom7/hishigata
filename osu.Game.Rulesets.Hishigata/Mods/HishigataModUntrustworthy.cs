using System;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModUntrustworthy : Mod, IApplicableToHitObject
    {
        public override string Name => "Untrustworthy";
        public override string Acronym => "UW";
        public override LocalisableString Description => HishigataModUntrustworthyStrings.ModDescription;
        public override ModType Type => ModType.Conversion;
        //Mod Icon currently looks ugly and does not fit in properly with other Icons, so needs updating.
        //public override IconUsage? Icon => FontAwesome.Solid.Exclamation;
        public override Type[] IncompatibleMods => new[] { typeof(HishigataModTrustworthy), typeof(HishigataModInvert) };

        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is HishigataNote hishigataNote) hishigataNote.IsFeign = true;
        }
    }
}
