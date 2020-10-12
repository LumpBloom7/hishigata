using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Rhombus.Replays
{
    public class RhombusFramedReplayInputHandler : FramedReplayInputHandler<RhombusReplayFrame>
    {
        public RhombusFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(RhombusReplayFrame frame) => frame.Actions.Any();

        public override void CollectPendingInputs(List<IInput> inputs)
        {
            inputs.Add(new ReplayState<RhombusAction>
            {
                PressedActions = CurrentFrame?.Actions ?? new List<RhombusAction>(),
            });
        }
    }
}
