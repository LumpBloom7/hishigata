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
            int currentLane = 0;
            Frames.Add(new HishigataReplayFrame());

            foreach (HishigataHitObject hitObject in Beatmap.HitObjects)
            {
                switch (hitObject)
                {
                    case HishigataNote note:
                        if (currentLane != note.Lane)
                        {
                            Frames.Add(new HishigataReplayFrame(hitObject.StartTime, (HishigataAction)note.Lane));
                            Frames.Add(new HishigataReplayFrame(hitObject.StartTime + 20));
                            currentLane = note.Lane;
                        }
                        break;
                    case HishigataClap _:
                        Frames.Add(new HishigataReplayFrame(hitObject.StartTime, HishigataAction.Clap));
                        Frames.Add(new HishigataReplayFrame(hitObject.StartTime + 20));
                        break;

                }

            }
            return Replay;
        }
    }
}
