using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Rhombus.Objects;
using System.Threading;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Rhombus.Beatmaps
{
    public class RhombusBeatmapConverter : BeatmapConverter<RhombusHitObject>
    {
        public RhombusBeatmapConverter(IBeatmap beatmap, Ruleset ruleset)
            : base(beatmap, ruleset)
        {
        }

        // todo: Check for conversion types that should be supported (ie. Beatmap.HitObjects.Any(h => h is IHasXPosition))
        // https://github.com/ppy/osu/tree/master/osu.Game/Rulesets/Objects/Types
        public override bool CanConvert() => true;

        protected override IEnumerable<RhombusHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap, CancellationToken cancellationToken)
        {
            yield return new RhombusHitObject
            {
                Samples = original.Samples,
                StartTime = original.StartTime,
            };
        }
    }
}
