using System;
using osu.Framework.Bindables;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataHitObject : HitObject
    {
        public double TimePreempt;

        public override Judgement CreateJudgement() => new Judgement();

        protected override void ApplyDefaultsToSelf(ControlPointInfo controlPointInfo, BeatmapDifficulty difficulty)
        {
            base.ApplyDefaultsToSelf(controlPointInfo, difficulty);

            TimePreempt = (float)BeatmapDifficulty.DifficultyRange(difficulty.ApproachRate, 1800, 1200, 450);
            TimePreempt /= controlPointInfo.DifficultyPointAt(StartTime).SpeedMultiplier;
            TimePreempt = Math.Max(TimePreempt, 450);
        }
    }
}
