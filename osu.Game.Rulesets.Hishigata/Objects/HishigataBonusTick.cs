using osu.Game.Rulesets.Hishigata.Judgements;
using osu.Game.Rulesets.Judgements;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataBonusTick : HishigataHitObject
    {
        public override Judgement CreateJudgement() => new HishigataBonusJudgement();
    }
}
