using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Hishigata.Objects;
using System.Threading;
using System.Collections.Generic;
using osuTK;
using System;
using System.Linq;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.Hishigata.Beatmaps
{
    public class HishigataBeatmapConverter : BeatmapConverter<HishigataHitObject>
    {
        public HishigataBeatmapConverter(IBeatmap beatmap, Ruleset ruleset)
            : base(beatmap, ruleset)
        {
        }

        // todo: Check for conversion types that should be supported (ie. Beatmap.HitObjects.Any(h => h is IHasXPosition))
        // https://github.com/ppy/osu/tree/master/osu.Game/Rulesets/Objects/Types
        public override bool CanConvert() => Beatmap.HitObjects.All(x => x is IHasPosition);

        protected override IEnumerable<HishigataHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap, CancellationToken cancellationToken)
        {
            Vector2 position = (original as IHasPosition).Position;
            float angle = getHitObjectAngle(position) / 90;
            int lane = (int)Math.Round(angle);

            if (lane >= 4) lane -= 4;

            yield return new HishigataHitObject
            {
                Lane = lane,
                Samples = original.Samples,
                StartTime = original.StartTime,
            };
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
