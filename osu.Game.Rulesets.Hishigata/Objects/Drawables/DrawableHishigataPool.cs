using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Pooling;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataPool<T> : DrawablePool<T>
        where T : DrawableHitObject, new()
    {
        private readonly Func<DrawableHishigataHitObject, bool> checkHittable;

        public DrawableHishigataPool(Func<DrawableHishigataHitObject, bool> checkHittable, int initialSize, int? maximumSize = null)
            : base(initialSize, maximumSize)
        {
            this.checkHittable = checkHittable;
        }

        protected override T CreateNewDrawable() => base.CreateNewDrawable().With(o =>
        {
            var hishiObject = (DrawableHishigataHitObject)(object)o;

            hishiObject.CanBeHit = checkHittable;
        });
    }
}
