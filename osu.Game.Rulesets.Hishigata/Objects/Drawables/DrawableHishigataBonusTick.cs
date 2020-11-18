using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataBonusTick : DrawableHishigataHitObject
    {
        public override bool DisplayResult => false;

        public DrawableHishigataBonusTick() : base(null)
        {
        }

        public DrawableHishigataBonusTick(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
        }

        public void TriggerResult(bool hit)
        {
            HitObject.StartTime = Time.Current;
            ApplyResult(r => r.Type = hit ? r.Judgement.MaxResult : r.Judgement.MinResult);
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
        }
    }
}
