using System.Collections.Generic;
using osu.Game.Replays;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.UI;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class HishigataReplayRecorder : ReplayRecorder<HishigataAction>
    {
        public HishigataReplayRecorder(Replay replay)
            : base(replay)
        {
        }

        protected override ReplayFrame HandleFrame(Vector2 mousePosition, List<HishigataAction> actions, ReplayFrame previousFrame)
            => new HishigataReplayFrame(Time.Current, actions.ToArray());
    }
}
