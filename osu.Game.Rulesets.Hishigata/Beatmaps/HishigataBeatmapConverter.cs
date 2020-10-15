using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Hishigata.Objects;
using System.Threading;
using System.Collections.Generic;
using osuTK;
using System;
using System.Linq;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Audio;
using System.Diagnostics;

namespace osu.Game.Rulesets.Hishigata.Beatmaps
{
    public class HishigataBeatmapConverter : BeatmapConverter<HishigataHitObject>
    {
        public HishigataBeatmapConverter(IBeatmap beatmap, Ruleset ruleset)
            : base(beatmap, ruleset)
        {
        }

        protected override Beatmap<HishigataHitObject> CreateBeatmap() => new HishigataBeatmap();

        // todo: Check for conversion types that should be supported (ie. Beatmap.HitObjects.Any(h => h is IHasXPosition))
        // https://github.com/ppy/osu/tree/master/osu.Game/Rulesets/Objects/Types
        public override bool CanConvert() => Beatmap.HitObjects.All(x => x is IHasPosition);

        protected override IEnumerable<HishigataHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap, CancellationToken cancellationToken)
        {
            var difficulty = beatmap.BeatmapInfo.BaseDifficulty;
            int seed = ((int)MathF.Round(difficulty.DrainRate + difficulty.CircleSize) * 20) + (int)(difficulty.OverallDifficulty * 41.2) + (int)MathF.Round(difficulty.ApproachRate);
            Random rng = new Random(seed);

            Vector2 position = (original as IHasPosition).Position;
            float angle = getHitObjectAngle(position) / 90;
            int lane = (int)Math.Round(angle);

            bool isFeign = original.Samples.Any(x => x.Name == HitSampleInfo.HIT_WHISTLE);

            if (lane >= 4) lane -= 4;
            switch (original)
            {
                case IHasPathWithRepeats _:
                    goto default;

                case IHasDuration spinner:
                    double spacing = spinner.Duration;
                    while (spacing > 100)
                        spacing /= 2;

                    if (spacing <= 0)
                        break;

                    double time = original.StartTime;
                    int i = 0;

                    while (time <= original.GetEndTime())
                    {
                        yield return new HishigataBonus
                        {
                            Lane = rng.Next(0, 4),
                            StartTime = time
                        };

                        time += spacing;
                        i++;
                    }
                    break;


                default:
                    yield return new HishigataHitObject
                    {
                        Lane = lane,
                        Samples = original.Samples,
                        StartTime = original.StartTime,
                        IsFeign = isFeign
                    };
                    break;

            }
        }
        private float getHitObjectAngle(Vector2 target)
        {
            Vector2 direction = target - new Vector2(256, 192);
            float angle = MathHelper.RadiansToDegrees(MathF.Atan2(direction.Y, direction.X));
            if (angle < 0f) angle += 360f;
            return angle + 90;
        }


    }
}
