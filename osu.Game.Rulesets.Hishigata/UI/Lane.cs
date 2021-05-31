using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Pooling;
using osu.Framework.Input;
using osu.Framework.Input.Events;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.UI.Components;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class Lane : Playfield
    {
        private readonly Container hitExplosionContainer;

        private readonly DrawablePool<PoolableHitExplosion> hitExplosionPool;

        public Lane()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddRangeInternal(new Drawable[]{
                hitExplosionPool = new DrawablePool<PoolableHitExplosion>(3),
                hitExplosionContainer = new Container(),
                HitObjectContainer,
            });
            NewResult += onNewResult;
        }

        private Func<DrawableHishigataHitObject, bool> checkHittable;

        [BackgroundDependencyLoader]
        private void load(PlayerVisual playerobj)
        {
            checkHittable = playerobj.CanBeHit;
            RegisterPool<HishigataNote, DrawableHishigataNote>(10);
            RegisterPool<HishigataBonus, DrawableHishigataBonus>(10);
        }

        public override void Add(DrawableHitObject h)
        {
            h.OnNewResult += onNewResult;
            base.Add(h);
        }

        protected override void OnNewDrawableHitObject(DrawableHitObject drawableHitObject)
        {
            base.OnNewDrawableHitObject(drawableHitObject);

            if (drawableHitObject is DrawableHishigataHitObject hishiObj)
                hishiObj.CanBeHit = checkHittable;
        }

        private void onNewResult(DrawableHitObject h, JudgementResult judgement)
        {
            if (judgement.IsHit)
                hitExplosionContainer.Add(hitExplosionPool.Get(e => e.Apply(h as DrawableHishigataHitObject)));
        }

        protected override HitObjectLifetimeEntry CreateLifetimeEntry(HitObject hitObject) => new HishigataHitObjectLifetimeEntry(hitObject);
    }
}
