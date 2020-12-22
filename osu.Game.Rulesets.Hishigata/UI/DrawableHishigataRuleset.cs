using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osu.Game.Scoring;

namespace osu.Game.Rulesets.Hishigata.UI
{
    [Cached]
    public class DrawableHishigataRuleset : DrawableRuleset<HishigataHitObject>
    {
        public DrawableHishigataRuleset(HishigataRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
        }

        protected override Playfield CreatePlayfield() => new HishigataPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new HishigataFramedReplayInputHandler(replay);

        public override DrawableHitObject<HishigataHitObject> CreateDrawableRepresentation(HishigataHitObject h) => null;

        protected override PassThroughInputManager CreateInputManager() => new HishigataInputManager(Ruleset?.RulesetInfo);

        protected override ReplayRecorder CreateReplayRecorder(Score score) => new HishigataReplayRecorder(score);
    }
}
