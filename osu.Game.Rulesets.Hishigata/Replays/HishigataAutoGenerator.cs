using System.Collections.Generic;
using System.Linq;
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
            int currentLane = 0;
            Frames.Add(new HishigataReplayFrame());

            foreach (HishigataLanedHitObject hitObject in Beatmap.HitObjects.OfType<HishigataLanedHitObject>())
            {
                if (currentLane != hitObject.Lane)
                {
                    Frames.Add(new HishigataReplayFrame(hitObject.StartTime, (HishigataAction)hitObject.Lane));
                    Frames.Add(new HishigataReplayFrame(hitObject.StartTime + 20));
                    currentLane = hitObject.Lane;
                }
            }
            return Replay;
        }
    }
}
