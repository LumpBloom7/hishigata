using osu.Framework.Graphics;
using osuTK.Graphics;
using osuTK;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Graphics;
using osu.Game.Rulesets.Objects;
using osu.Framework.Graphics.Containers;
using osu.Framework.Bindables;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataBonus : DrawableHishigataHitObject
    {
        protected override double InitialLifetimeOffset => 500;

        public DrawableHishigataBonus() : this(null)
        { }

        private OsuSpriteText spinText;
        private Container bgFill;
        private Container<DrawableHishigataBonusTick> tickContainer;

        public BindableInt RotateAmount = new BindableInt();

        public DrawableHishigataBonus(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
            Size = new Vector2(450);
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RotateAmount.BindValueChanged(handlePlayerRotation);
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(bgFill = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = Vector2.Zero,
                RelativeSizeAxes = Axes.Both,
                Rotation = 45,
                Masking = true,
                BorderThickness = 10,
                BorderColour = Color4.Blue,
                Alpha = 0.2f,
                Child = new Box
                {
                    Colour = Color4.Aqua,
                    RelativeSizeAxes = Axes.Both,
                }
            });

            AddInternal(spinText = new OsuSpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "SPIN",
                Font = OsuFont.Torus.With(size: 50),
                Colour = Color4.White,
                Position = new Vector2(0, -100),
                Alpha = 0,
                Scale = Vector2.Zero
            });


            AddInternal(tickContainer = new Container<DrawableHishigataBonusTick>());
        }

        protected override void UpdateInitialTransforms()
        {
            base.UpdateInitialTransforms();
            spinText.ScaleTo(1, InitialLifetimeOffset).FadeInFromZero(InitialLifetimeOffset);
        }

        protected override DrawableHitObject CreateNestedHitObject(HitObject hitObject)
        {
            switch (hitObject)
            {
                case HishigataBonusTick _:
                    return new DrawableHishigataBonusTick();
                default:
                    return base.CreateNestedHitObject(hitObject);
            }
        }

        protected override void AddNestedHitObject(DrawableHitObject hitObject)
        {
            base.AddNestedHitObject(hitObject);
            switch (hitObject)
            {
                case DrawableHishigataBonusTick tick:
                    tickContainer.Add(tick);
                    break;
            }
        }

        protected override void Update()
        {
            base.Update();
            float progress = 0;
            if (tickContainer.Any())
                progress = tickContainer.Count(x => x.Judged) / (float)tickContainer.Count;

            bgFill.Size = new Vector2(progress);
        }

        protected override void ClearNestedHitObjects()
        {
            base.ClearNestedHitObjects();
            tickContainer.Clear(false);
        }

        private void handlePlayerRotation(ValueChangedEvent<int> streak)
        {
            if (IsInUse && Time.Current > HitObject.StartTime)
            {
                if (streak.NewValue > 1)
                    tickContainer.FirstOrDefault(t => !t.Judged)?.TriggerResult(true);
            }
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (Time.Current > HitObject.GetEndTime())
            {
                ApplyResult(r => r.Type = r.Judgement.MinResult);
                return;
            }

            if (tickContainer.All(x => x.Judged))
            {
                ApplyResult(r => r.Type = r.Judgement.MaxResult);
                return;
            }
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            switch (state)
            {
                case ArmedState.Hit:
                    this.ScaleTo(1.1f, 200).FadeOut(200).Expire();
                    break;
                case ArmedState.Miss:
                    this.ScaleTo(0, 200).FadeOut(200).Expire();
                    break;
            }
        }
    }
}
