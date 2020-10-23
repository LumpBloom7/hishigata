using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Pooling;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class PoolableHitExplosion : PoolableDrawable
    {
        private Box left;
        private Box right;

        private double duration;

        public PoolableHitExplosion()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Position = new Vector2(0, -80);
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                left = new Box
                {
                    Origin = Anchor.CentreRight,
                    Anchor = Anchor.Centre,
                    Rotation = -45
                },
                right = new Box
                {
                    Origin = Anchor.CentreLeft,
                    Anchor = Anchor.Centre,
                    Rotation = 45
                },
            };
        }

        public void Apply(DrawableHishigataHitObject h)
        {
            duration = h.HitObject.TimePreempt / 3;
            Colour = h.Colour;
        }

        protected override void PrepareForUse()
        {
            base.PrepareForUse();

            left.ResizeTo(new Vector2(0, 4)).Then().ResizeWidthTo(100, duration).ResizeHeightTo(0, duration).Expire(true);
            right.ResizeTo(new Vector2(0, 4)).Then().ResizeWidthTo(100, duration).ResizeHeightTo(0, duration).Expire(true);
            this.Delay(duration).Then().Expire(true);
        }
    }
}
