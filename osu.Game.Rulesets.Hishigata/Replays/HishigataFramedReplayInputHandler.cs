using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Hishigata.Replays
{
    public class HishigataFramedReplayInputHandler : FramedReplayInputHandler<HishigataReplayFrame>
    {
        public HishigataFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(HishigataReplayFrame frame) => frame.Actions.Any();

        public override void CollectPendingInputs(List<IInput> inputs)
        {
            inputs.Add(new ReplayState<HishigataAction>
            {
                PressedActions = CurrentFrame?.Actions ?? new List<HishigataAction>(),
            });
        }
    }
}
