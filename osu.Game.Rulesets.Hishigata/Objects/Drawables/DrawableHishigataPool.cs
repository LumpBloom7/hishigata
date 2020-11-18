using System;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Pooling;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataPool<T> : DrawablePool<T>
        where T : DrawableHitObject, new()
    {
        private readonly Func<DrawableHishigataLanedHitObject, bool> checkHittable;
        private readonly BindableInt rotationStreak;

        public DrawableHishigataPool(Func<DrawableHishigataLanedHitObject, bool> checkHittable, BindableInt rotationStreak, int initialSize, int? maximumSize = null)
            : base(initialSize, maximumSize)
        {
            this.checkHittable = checkHittable;
            this.rotationStreak = rotationStreak;
        }

        protected override T CreateNewDrawable() => base.CreateNewDrawable().With(o =>
        {
            switch (o)
            {
                case DrawableHishigataLanedHitObject laned:
                    laned.CanBeHit = checkHittable;
                    break;
                case DrawableHishigataBonus bonus:
                    bonus.RotateAmount.BindTo(rotationStreak);
                    break;
            }
        });
    }
}
