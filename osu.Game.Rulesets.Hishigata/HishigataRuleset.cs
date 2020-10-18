
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Hishigata.Beatmaps;
using osu.Game.Rulesets.Hishigata.Mods;
using osu.Game.Rulesets.Hishigata.UI;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Replays.Types;
using System;
using osu.Framework.Graphics.Containers;
using osuTK;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.Hishigata.Difficulty;

namespace osu.Game.Rulesets.Hishigata
{
    public class HishigataRuleset : Ruleset
    {
        public override string Description => "hishigata";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) => new DrawableHishigataRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new HishigataBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) => new HishigataDifficultyCalculator(this, beatmap);

        public override IConvertibleReplayFrame CreateConvertibleReplayFrame() => new HishigataReplayFrame();

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new HishigataModAutoplay() };

                default:
                    return Array.Empty<Mod>();
            }
        }

        public override string ShortName => "hishigata";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Up, HishigataAction.Up),
            new KeyBinding(InputKey.W, HishigataAction.Up),
            new KeyBinding(InputKey.Right, HishigataAction.Right),
            new KeyBinding(InputKey.D, HishigataAction.Right),
            new KeyBinding(InputKey.Down, HishigataAction.Down),
            new KeyBinding(InputKey.S, HishigataAction.Down),
            new KeyBinding(InputKey.Left, HishigataAction.Left),
            new KeyBinding(InputKey.A, HishigataAction.Left),
        };

        public override Drawable CreateIcon() => new Container
        {
            Size = new Vector2(40),
            Children = new Drawable[]
            {
                new SpriteIcon
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Icon = FontAwesome.Regular.Circle,
                },
                new SpriteIcon
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Icon = FontAwesome.Solid.ChevronUp,
                    Size = new Vector2(25),
                    Position = new Vector2(0,-2f)
                },
            }
        };
    }
}
