
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Rhombus.Objects.Drawables;
using osu.Game.Rulesets.Rhombus.UI.Components;
using osu.Game.Rulesets.UI;
using osuTK;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Rhombus.UI
{
    [Cached]
    public class RhombusPlayfield : Playfield
    {
        private readonly List<Lane> lanes = new List<Lane>();
        private readonly PlayerVisual playerObject;
        public RhombusPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.None;
            Size = new Vector2(600);
            AddRangeInternal(new Drawable[]
            {
                HitObjectContainer,
                playerObject= new PlayerVisual()
            });

            for (int i = 0; i < 4; ++i)
            {
                var lane = new Lane
                {
                    Rotation = 90 * i
                };
                lanes.Add(lane);
                AddInternal(lane);
            }
        }

        public override void Add(DrawableHitObject hitObject)
        {
            var rhombusObject = hitObject as DrawableRhombusHitObject;

            rhombusObject.CanBeHit = playerObject.CanBeHit;
            lanes[rhombusObject.HitObject.Lane].Add(hitObject);
        }
    }
}
