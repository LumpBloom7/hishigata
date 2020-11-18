using System;
using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Hishigata.Judgements;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Types;
using System.Threading;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataBonus : HishigataHitObject, IHasDuration
    {
        public double EndTime
        {
            get => StartTime + Duration;
            set => Duration = value - StartTime;
        }

        public double Duration { get; set; }

        public override Judgement CreateJudgement() => new IgnoreJudgement();

        protected override void CreateNestedHitObjects(CancellationToken cancellationToken)
        {
            base.CreateNestedHitObjects(cancellationToken);

            int hitsRequired = (int)Math.Max(1, Duration / 200);

            for (int i = 0; i < hitsRequired; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                AddNested(new HishigataBonusTick());
            }
        }
    }
}
