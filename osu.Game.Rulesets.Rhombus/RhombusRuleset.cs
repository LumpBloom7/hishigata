
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Rhombus.Beatmaps;
using osu.Game.Rulesets.Rhombus.Mods;
using osu.Game.Rulesets.Rhombus.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Rhombus
{
    public class RhombusRuleset : Ruleset
    {
        public override string Description => "a very rhombus ruleset";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) => new DrawableRhombusRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new RhombusBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) => new RhombusDifficultyCalculator(this, beatmap);

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new RhombusModAutoplay() };

                default:
                    return new Mod[] { null };
            }
        }

        public override string ShortName => "rhombus";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Z, RhombusAction.Button1),
            new KeyBinding(InputKey.X, RhombusAction.Button2),
        };

        public override Drawable CreateIcon() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = ShortName[0].ToString(),
            Font = OsuFont.Default.With(size: 18),
        };
    }
}
