
using System.Collections.Generic;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Rhombus.Replays
{
    public class RhombusReplayFrame : ReplayFrame
    {
        public List<RhombusAction> Actions = new List<RhombusAction>();

        public RhombusReplayFrame(RhombusAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }
    }
}
