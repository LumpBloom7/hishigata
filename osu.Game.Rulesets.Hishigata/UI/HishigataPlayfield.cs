using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.UI.Components;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI
{
    [Cached]
    public class HishigataPlayfield : Playfield
    {
        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

        private readonly List<Lane> lanes = new List<Lane>();
        private Container playfieldContainer;

        [Cached]
        private PlayerVisual playerObject;

        public HishigataPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddRangeInternal(new Drawable[]{
                new EffectContainer(),
                new Container
                {
                    Size = new Vector2(113.137f),
                    Rotation = 45,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderThickness = 2,
                    BorderColour = Color4.LightGray,
                    Child = new Box
                    {
                        Alpha = 0,
                        RelativeSizeAxes = Axes.Both,
                        AlwaysPresent = true
                    }
                },
                new Rhombus().With(x => x.AddRange(new Drawable[]
                {
                    playfieldContainer = new Container
                    {
                        Rotation = -45,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Child = playerObject = new PlayerVisual()
                    },
                    HitObjectContainer
                }))
            });


            for (int i = 0; i < 4; ++i)
            {
                var lane = new Lane(i)
                {
                    Rotation = 90 * i
                };
                lanes.Add(lane);
                playfieldContainer.Add(lane);
                AddNested(lane);
            }
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            RegisterPool<HishigataClap, DrawableHishigataClap>(5);
        }

        protected override HitObjectLifetimeEntry CreateLifetimeEntry(HitObject hitObject) => new HishigataHitObjectLifetimeEntry(hitObject);

        public override void Add(HitObject hitObject)
        {
            switch (hitObject)
            {
                case HishigataNote note:
                    lanes[note.Lane].Add(hitObject);
                    break;
                case HishigataClap clap:
                    base.Add(clap);
                    break;
            }
        }
    }
}
