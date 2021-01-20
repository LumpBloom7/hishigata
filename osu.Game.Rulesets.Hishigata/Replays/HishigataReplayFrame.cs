using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Replays.Legacy;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.Replays.Types;

namespace osu.Game.Rulesets.Hishigata.Replays
{
    public class HishigataReplayFrame : ReplayFrame, IConvertibleReplayFrame
    {
        public List<HishigataAction> Actions = new List<HishigataAction>();

        public HishigataReplayFrame()
        {
        }

        public HishigataReplayFrame(double time, params HishigataAction[] actions)
            : base(time)
        {
            Actions.AddRange(actions);
        }

        public void FromLegacy(LegacyReplayFrame currentFrame, IBeatmap beatmap, ReplayFrame lastFrame = null)
        {
            if (currentFrame.MouseLeft1) Actions.Add(HishigataAction.Up);
            if (currentFrame.MouseLeft2) Actions.Add(HishigataAction.Right);
            if (currentFrame.MouseRight1) Actions.Add(HishigataAction.Down);
            if (currentFrame.MouseRight2) Actions.Add(HishigataAction.Left);
            if (currentFrame.ButtonState.HasFlag(ReplayButtonState.Smoke)) Actions.Add(HishigataAction.Clap);
        }

        public LegacyReplayFrame ToLegacy(IBeatmap beatmap)
        {
            ReplayButtonState state = ReplayButtonState.None;

            if (Actions.Contains(HishigataAction.Up)) state |= ReplayButtonState.Left1;
            if (Actions.Contains(HishigataAction.Right)) state |= ReplayButtonState.Left2;
            if (Actions.Contains(HishigataAction.Down)) state |= ReplayButtonState.Right1;
            if (Actions.Contains(HishigataAction.Left)) state |= ReplayButtonState.Right2;
            if (Actions.Contains(HishigataAction.Clap)) state |= ReplayButtonState.Smoke;

            return new LegacyReplayFrame(Time, null, null, state);
        }
    }
}
