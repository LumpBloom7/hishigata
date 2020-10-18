
using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Hishigata.Beatmaps;
using osu.Game.Rulesets.Hishigata.Difficulty;
using osu.Game.Rulesets.Hishigata.Mods;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Hishigata.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Replays.Types;
using osu.Game.Rulesets.UI;
using osuTK;

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
                case ModType.DifficultyReduction:
                    return new Mod[]
                    {
                        new MultiMod(new HishigataModHalfTime(), new HishigataModDaycore()),
                        new HishigataModNoFail(),
                    };

                case ModType.DifficultyIncrease:
                    return new Mod[]
                    {
                        new HishigataModHardRock(),
                        new MultiMod(new HishigataModSuddenDeath(), new HishigataModPerfect()),
                        new MultiMod(new HishigataModDoubleTime(), new HishigataModNightcore()),
                    };

                case ModType.Automation:
                    return new Mod[]
                    {
                        new HishigataModAutoplay(),
                    };

                case ModType.Fun:
                    return new Mod[]
                    {
                        new MultiMod(new ModWindUp(), new ModWindDown()),
                    };

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
