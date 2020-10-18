using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.UI
{
    internal class HitExplosion : CompositeDrawable
    {
        public override bool RemoveWhenNotAlive => true;

        private readonly Box left;
        private readonly Box right;
        private readonly double animationTime;

        public HitExplosion(DrawableHishigataHitObject h)
        {
            animationTime = h.HitObject.TimePreempt / 3;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Position = new Vector2(0, -80);
            Colour = h.Colour;
            InternalChildren = new Drawable[]
            {
                left = new Box
                {
                    Origin = Anchor.CentreRight,
                    Anchor = Anchor.Centre,
                    Size = new Vector2(0,4),
                    Rotation = -45
                },
                right = new Box
                {
                    Origin = Anchor.CentreLeft,
                    Anchor = Anchor.Centre,
                    Size = new Vector2(0,4),
                    Rotation = 45
                },
            };

        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            left.ResizeWidthTo(100, animationTime).ResizeHeightTo(0, animationTime);
            right.ResizeWidthTo(100, animationTime).ResizeHeightTo(0, animationTime);
            this.Delay(animationTime).Expire();
        }
    }
}
