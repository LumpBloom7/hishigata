using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataHitObject : DrawableHitObject<HishigataHitObject>
    {
        protected override double InitialLifetimeOffset => HitObject.TimePreempt;
        protected Container Note;

        public DrawableHishigataHitObject() : base(null)
        {
        }

        public DrawableHishigataHitObject(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            AddInternal(Note = new Container
            {
                Position = new Vector2(0, -300),
                Size = new Vector2(50),
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Child = new SpriteIcon
                {
                    RelativeSizeAxes = Axes.Both,
                    Icon = FontAwesome.Solid.ChevronDown,
                }
            });
        }

        protected override void OnApply(HitObject hitObject)
        {
            base.OnApply(hitObject);
            LifetimeStart = HitObject.StartTime - InitialLifetimeOffset;
        }

        public Func<DrawableHishigataHitObject, bool> CanBeHit;

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0 && timeOffset <= 32)
            {
                if (CanBeHit?.Invoke(this) ?? false)
                    ApplyResult(r => r.Type = r.Judgement.MaxResult);

                return;
            }
            if (timeOffset > 32)
                ApplyResult(r => r.Type = r.Judgement.MinResult);
        }

        protected override void UpdateInitialTransforms()
        {
            Note.MoveTo(new Vector2(0, -80), HitObject.TimePreempt);
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            double animationDuration = HitObject.TimePreempt / 6;

            switch (state)
            {
                case ArmedState.Hit:
                    Note.ScaleTo(0, animationDuration);
                    this.Delay(animationDuration).Expire();
                    break;

                case ArmedState.Miss:
                    Note.MoveToOffset(new Vector2(0, 80), animationDuration).FadeColour(Color4.Red, animationDuration).FadeOut(animationDuration);
                    this.Delay(150).Expire();
                    break;
            }
        }
    }
}
