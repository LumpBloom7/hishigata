
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Replays;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Hishigata.Replays
{
    public class HishigataAutoGenerator : AutoGenerator
    {
        protected Replay Replay;
        protected List<ReplayFrame> Frames => Replay.Frames;

        public new Beatmap<HishigataHitObject> Beatmap => (Beatmap<HishigataHitObject>)base.Beatmap;

        public HishigataAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
            Replay = new Replay();
        }

        public override Replay Generate()
        {
            Frames.Add(new HishigataReplayFrame());

            foreach (HishigataHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new HishigataReplayFrame
                {
                    Time = hitObject.StartTime
                    // todo: add required inputs and extra frames.
                });
            }

            return Replay;
        }
    }
}
