using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Hishigata.Scoring
{
    public partial class HishigataScoreProcessor : ScoreProcessor
    {
        public HishigataScoreProcessor(HishigataRuleset ruleset) : base(ruleset) { }
        protected override double ComputeTotalScore(double comboProgress, double accuracyProgress, double bonusPortion)
        {
            return (500000 * comboProgress) + (500000 * accuracyProgress) + bonusPortion;
        }
    }
}
