using osu.Game.Rulesets.Hishigata.Judgements;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataHitObject : HitObject
    {
        public override Judgement CreateJudgement() => new Judgement();

        protected override HitWindows CreateHitWindows() => HitWindows.Empty;
    }
}
