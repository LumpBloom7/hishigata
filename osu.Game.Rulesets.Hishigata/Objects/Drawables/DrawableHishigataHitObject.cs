
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics.Containers;
using osu.Framework.Extensions.Color4Extensions;
using System;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataHitObject : DrawableHitObject<HishigataHitObject>
    {
        protected override double InitialLifetimeOffset => HitObject.TimePreempt;

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
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre
                }
            });
        }

        public Func<DrawableHishigataHitObject, bool> CanBeHit;

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= -10 && timeOffset <= 100)
            {
                if (CanBeHit?.Invoke(this) ?? false)
                    ApplyResult(r => r.Type = HitResult.Perfect);

                return;
            }
            if (timeOffset > 100)
                ApplyResult(r => r.Type = HitResult.Miss);
        }

        protected override void UpdateInitialTransforms()
        {
            base.UpdateInitialTransforms();
            if (HitObject.IsFeign)
                this.Delay(HitObject.TimePreempt * .3).Then().RotateTo(360, HitObject.TimePreempt * .3).FadeColour(Color4.White, HitObject.TimePreempt * .2);

            note.MoveTo(new Vector2(0, -80), HitObject.TimePreempt);
        }


        protected override void UpdateStateTransforms(ArmedState state)
        {
            const double duration = 300;

            switch (state)
            {
                case ArmedState.Hit:
                    note.FadeOut().Expire();
                    break;

                case ArmedState.Miss:

                    note.FadeColour(Color4.Red, duration);
                    note.FadeOut(duration, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
