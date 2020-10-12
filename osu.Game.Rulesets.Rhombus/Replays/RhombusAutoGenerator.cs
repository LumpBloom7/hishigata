
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Replays;
using osu.Game.Rulesets.Rhombus.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Rhombus.Replays
{
    public class RhombusAutoGenerator : AutoGenerator
    {
        protected Replay Replay;
        protected List<ReplayFrame> Frames => Replay.Frames;

        public new Beatmap<RhombusHitObject> Beatmap => (Beatmap<RhombusHitObject>)base.Beatmap;

        public RhombusAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
            Replay = new Replay();
        }

        public override Replay Generate()
        {
            Frames.Add(new RhombusReplayFrame());

            foreach (RhombusHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new RhombusReplayFrame
                {
                    Time = hitObject.StartTime
                    // todo: add required inputs and extra frames.
                });
            }

            return Replay;
        }
    }
}
