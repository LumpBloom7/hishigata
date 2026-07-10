using osu.Game.Rulesets.Hishigata.Mods;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Hishigata.Scoring;

public class HishigataScoreMultiplierCalculator : ScoreMultiplierCalculator
{
    public HishigataScoreMultiplierCalculator(ScoreMultiplierContext context) : base(context)
    {
        #region Difficulty Reduction
        Single<HishigataModDaycore>(hasMultiplier: 0.3);
        Single<HishigataModHalfTime>(hasMultiplier: 0.3);
        // No-fail
        #endregion

        #region Difficulty Increase
        Single<HishigataModDoubleTime>(hasMultiplier: 1.12);
        Single<HishigataModHardRock>(hasMultiplier: 1.06);
        Single<HishigataModHidden>(hasMultiplier: 1.06);
        Single<HishigataModNightcore>(hasMultiplier: 1.12);
        // Sudden death
        #endregion

        #region Automation
        // Autoplay
        #endregion

        #region Conversion
        Single<HishigataModTrustworthy>(hasMultiplier: 0.8);
        Single<HishigataModUntrustworthy>(hasMultiplier: 0.8);
        #endregion
    }
}
