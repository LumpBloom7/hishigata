using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Hishigata.Scoring
{
    public class HishigataScoreProcessor : ScoreProcessor
    {
        public HishigataScoreProcessor(HishigataRuleset ruleset) : base(ruleset) { }
        protected override double DefaultAccuracyPortion => 0.5;
        protected override double DefaultComboPortion => 0.5;
    }
}
