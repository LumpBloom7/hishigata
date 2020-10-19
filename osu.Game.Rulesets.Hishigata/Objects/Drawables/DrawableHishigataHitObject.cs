
using System;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataHitObject : DrawableHitObject<HishigataHitObject>
    {
        protected override double InitialLifetimeOffset => HitObject.TimePreempt + (HitObject.IsFeign ? 200 : 0);

        private readonly Container note;
        public DrawableHishigataHitObject(HishigataHitObject hitObject)
            : base(hitObject)
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Rotation = HitObject.IsFeign ? 180 : 0;
            Colour = HitObject.IsFeign ? Color4Extensions.FromHex("ff0064") : Color4.White;
            AddInternal(note = new Container
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
            if (HitObject.IsFeign)
            {
                note.MoveTo(new Vector2(0, -190), HitObject.TimePreempt * .5).Then().Delay(200).MoveTo(new Vector2(0, -80), HitObject.TimePreempt * .5);
                this.Delay(HitObject.TimePreempt * .5).Then().RotateTo(360, 200).FadeColour(Color4.White, 200);
            }
            else
                note.MoveTo(new Vector2(0, -80), HitObject.TimePreempt);
        }


        protected override void UpdateStateTransforms(ArmedState state)
        {
            double animationDuration = HitObject.TimePreempt / 6;

            switch (state)
            {
                case ArmedState.Hit:
                    note.ScaleTo(0, animationDuration).Expire();
                    this.Delay(animationDuration).Expire();
                    break;

                case ArmedState.Miss:
                    note.MoveToOffset(new Vector2(0, 80), animationDuration).FadeColour(Color4.Red, animationDuration).FadeOut(animationDuration).Expire();
                    this.Delay(150).Expire();
                    break;
            }
        }
    }
}
