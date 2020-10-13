
using osu.Framework.Bindables;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.Rhombus.Objects
{
    public class RhombusHitObject : HitObject
    {
        public double TimePreempt;

        public BindableInt LaneBindable = new BindableInt();
        public int Lane
        {
            get => LaneBindable.Value;
            set => LaneBindable.Value = value;
        }

        public override Judgement CreateJudgement() => new Judgement();

        protected override void ApplyDefaultsToSelf(ControlPointInfo controlPointInfo, BeatmapDifficulty difficulty)
        {
            base.ApplyDefaultsToSelf(controlPointInfo, difficulty);

            TimePreempt = (float)BeatmapDifficulty.DifficultyRange(difficulty.ApproachRate, 1800, 1200, 450);
            TimePreempt /= controlPointInfo.DifficultyPointAt(StartTime).SpeedMultiplier;
        }
    }
}
