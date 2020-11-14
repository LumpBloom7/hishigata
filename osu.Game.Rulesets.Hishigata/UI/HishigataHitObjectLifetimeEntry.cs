using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class HishigataHitObjectLifetimeEntry : HitObjectLifetimeEntry
    {
        protected override double InitialLifetimeOffset => ((HishigataHitObject)HitObject).TimePreempt + ((isFeign) ? 200 : 0);

        private bool isFeign => HitObject is HishigataNote n && n.IsFeign;

        public HishigataHitObjectLifetimeEntry(HitObject hitObject) : base(hitObject) { }
    }
}
