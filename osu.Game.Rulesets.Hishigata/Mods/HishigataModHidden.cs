using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Hishigata.Localisation.Mods;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModHidden : ModHidden
    {
        public override LocalisableString Description => HishigataModHiddenStrings.ModDescription;

        public override double ScoreMultiplier => 1.06;

        protected override void ApplyIncreasedVisibilityState(DrawableHitObject hitObject, ArmedState state) => ApplyNormalVisibilityState(hitObject, state);

        protected override void ApplyNormalVisibilityState(DrawableHitObject hitObject, ArmedState state)
        {
            DrawableHishigataHitObject hishiObj = (DrawableHishigataHitObject)hitObject;

            using (hishiObj.BeginAbsoluteSequence(hishiObj.HitObject.StartTime - hishiObj.HitObject.TimePreempt))
                hishiObj.FadeOut(hishiObj.HitObject.TimePreempt / 1.5f);
        }
    }
}
