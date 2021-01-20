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
                Colour = Color4.BlueViolet,
                Size = new Vector2(450),
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Children = new Drawable[]{
                    new Box
                    {
                        Anchor = Anchor.TopCentre,
                        Origin = Anchor.TopCentre,
                        Size = new Vector2(113.137f, 5)
                    },
                    new Box
                    {
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.BottomCentre,
                        Size = new Vector2(113.137f, 5)
                    },
                    new Box
                    {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Size = new Vector2(5, 113.137f)
                    },
                    new Box
                    {
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Size = new Vector2(5, 113.137f)
                    }
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
            Note.ResizeTo(113.137f, HitObject.TimePreempt);
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
