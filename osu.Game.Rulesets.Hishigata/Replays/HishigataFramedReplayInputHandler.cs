using System.Collections.Generic;
using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Hishigata.Replays
{
    public class HishigataFramedReplayInputHandler : FramedReplayInputHandler<HishigataReplayFrame>
    {
        public HishigataFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(HishigataReplayFrame frame) => frame.Actions.Any();

        protected override void CollectReplayInputs(List<IInput> inputs)
        {
            inputs.Add(new ReplayState<HishigataAction>
            {
                PressedActions = CurrentFrame?.Actions ?? new List<HishigataAction>(),
            });
        }
    }
}
