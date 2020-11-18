using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class HishigataHitObjectLifetimeEntry : HitObjectLifetimeEntry
    {
        protected override double InitialLifetimeOffset => getInitialLifetimeOffset();

        public HishigataHitObjectLifetimeEntry(HitObject hitObject) : base(hitObject) { }

        private double getInitialLifetimeOffset()
        {
            switch (HitObject)
            {
                case HishigataLanedHitObject laned:
                    return laned.IsFeign ? laned.TimePreempt + 200 : laned.TimePreempt;
                case HishigataBonus _:
                    return 500;
                default:
                    return 0;
            }
        }
    }
}
