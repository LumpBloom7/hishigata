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
                new Rhombus().With(x => x.Add(playfieldContainer = new Container
                {
                    Rotation = -45,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = playerObject = new PlayerVisual()
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

        public override void Add(HitObject hitObject)
        {
            var hishiObj = hitObject as HishigataHitObject;
            lanes[hishiObj.Lane].Add(hitObject);
        }

        public override void Add(DrawableHitObject hitObject)
        {
            var hishigataObject = hitObject as DrawableHishigataHitObject;

            hishigataObject.CanBeHit = playerObject.CanBeHit;
            lanes[hishigataObject.HitObject.Lane].Add(hitObject);
        }
    }
}
