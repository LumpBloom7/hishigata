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

        public BindableInt LaneBindable = new BindableInt();

        public double Velocity { get; set; } = 1;

        public int Lane
        {
            get => LaneBindable.Value;
            set => LaneBindable.Value = value;
        }

        public override Judgement CreateJudgement() => new Judgement();

        protected override void ApplyDefaultsToSelf(ControlPointInfo controlPointInfo, IBeatmapDifficultyInfo difficulty)
        {
            base.ApplyDefaultsToSelf(controlPointInfo, difficulty);

            TimePreempt = (float)IBeatmapDifficultyInfo.DifficultyRange(difficulty.ApproachRate, 1800, 1200, 450);
            TimePreempt /= Velocity;
            TimePreempt = Math.Max(TimePreempt, 450);
        }
    }
}
