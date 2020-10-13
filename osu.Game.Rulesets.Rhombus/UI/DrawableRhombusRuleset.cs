
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Rhombus.Objects;
using osu.Game.Rulesets.Rhombus.Objects.Drawables;
using osu.Game.Rulesets.Rhombus.Replays;
using osu.Game.Rulesets.UI;
using osu.Game.Configuration;

namespace osu.Game.Rulesets.Rhombus.UI
{
    [Cached]
    public class DrawableRhombusRuleset : DrawableRuleset<RhombusHitObject>
    {
        public DrawableRhombusRuleset(RhombusRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
        }

        protected override Playfield CreatePlayfield() => new RhombusPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new RhombusFramedReplayInputHandler(replay);

        public override DrawableHitObject<RhombusHitObject> CreateDrawableRepresentation(RhombusHitObject h) => new DrawableRhombusHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new RhombusInputManager(Ruleset?.RulesetInfo);
    }
}
