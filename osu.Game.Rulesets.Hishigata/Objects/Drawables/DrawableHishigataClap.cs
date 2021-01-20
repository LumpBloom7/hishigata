using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataClap : DrawableHishigataHitObject, IKeyBindingHandler<HishigataAction>
    {
        public new HishigataClap HitObject => (HishigataClap)base.HitObject;

        protected Container Note;

        public DrawableHishigataClap() : base(null)
        {
        }

        public DrawableHishigataClap(HishigataClap hitObject = null)
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
                Masking = true,
                BorderColour = Color4.White,
                BorderThickness = 10,
                Size = new Vector2(1000),
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Rotation = 45,
                Alpha = 0,
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Alpha = 0,
                    AlwaysPresent = true
                }
            });
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (!userTriggered)
            {
                if (timeOffset > 150)
                    ApplyResult(r => r.Type = r.Judgement.MinResult);
                return;
            }

            if (timeOffset > -150)
                ApplyResult(r => r.Type = r.Judgement.MaxResult);
        }

        protected override void UpdateInitialTransforms()
        {
            Note.FadeInFromZero(HitObject.TimePreempt).ResizeTo(450, HitObject.TimePreempt);
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
            switch (state)
            {
                case ArmedState.Hit:
                    Note.ScaleTo(1.1f, 100).FadeOut(100);
                    this.Delay(100).Expire();
                    break;

                case ArmedState.Miss:
                    Note.ScaleTo(0.9f, 150).FadeColour(Color4.Red, 150).FadeOut(150);
                    this.Delay(150).Expire();
                    break;
            }
        }
        public bool OnPressed(HishigataAction action)
        {
            if (action == HishigataAction.Clap)
                return UpdateResult(true);
            return false;
        }

        public void OnReleased(HishigataAction action)
        {
        }
    }
}
