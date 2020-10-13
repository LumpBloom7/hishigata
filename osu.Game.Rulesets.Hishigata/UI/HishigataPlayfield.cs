
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.UI.Components;
using osu.Game.Rulesets.UI;
using osuTK;
using System.Collections.Generic;

namespace osu.Game.Rulesets.Hishigata.UI
{
    [Cached]
    public class HishigataPlayfield : Playfield
    {
        private readonly List<Lane> lanes = new List<Lane>();
        private readonly PlayerVisual playerObject;
        public HishigataPlayfield()
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
            var hishigataObject = hitObject as DrawableHishigataHitObject;

            hishigataObject.CanBeHit = playerObject.CanBeHit;
            lanes[hishigataObject.HitObject.Lane].Add(hitObject);
        }
    }
}
