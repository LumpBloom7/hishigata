using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Hishigata.Judgements
{
    public class HishigataBonusJudgement : Judgement
    {
        public override HitResult MaxResult => HitResult.LargeBonus;
    }
}
