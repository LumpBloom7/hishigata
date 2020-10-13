
using System.Collections.Generic;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Hishigata.Replays
{
    public class HishigataReplayFrame : ReplayFrame
    {
        public List<HishigataAction> Actions = new List<HishigataAction>();

        public HishigataReplayFrame(HishigataAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }
    }
}
