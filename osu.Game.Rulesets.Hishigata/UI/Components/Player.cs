using System;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Transforms;
using osu.Framework.Input.Bindings;
using osu.Framework.Utils;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.UI.Settings;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class PlayerVisual : BeatSyncedContainer, IKeyBindingHandler<HishigataAction>
    {
        private readonly Container rContainer;
        private readonly Container gContainer;
        private readonly Container bContainer;

        [Cached]
        private readonly Bindable<float> angleBindable = new Bindable<float>();

        private Container maskedArrow;
        private Container pathArrow;

        public PlayerVisual()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(100);
            InternalChildren = new Drawable[]{
                rContainer = new Container{
                    RelativeSizeAxes = Axes.Both,
                    Anchor= Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.Red,
                    BorderThickness = 20,
                    Rotation= 45,
                    Alpha = .33f,
                    Child = new Box{
                        RelativeSizeAxes = Axes.Both,
                        Alpha= 0,
                        AlwaysPresent = true
                    },
                },
                gContainer = new Container{
                    RelativeSizeAxes = Axes.Both,
                    Anchor= Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.Green,
                    BorderThickness = 20,
                    Rotation= 45,
                    Alpha = .33f,
                    Child = new Box{
                        RelativeSizeAxes = Axes.Both,
                        Alpha= 0,
                        AlwaysPresent = true
                    },
                },
                bContainer = new Container{
                    RelativeSizeAxes = Axes.Both,
                    Anchor= Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.Blue,
                    BorderThickness = 20,
                    Rotation= 45,
                    Alpha = .33f,
                    Child = new Box{
                        RelativeSizeAxes = Axes.Both,
                        Alpha= 0,
                        AlwaysPresent = true
                    },
                },
                new Container{
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.White,
                    BorderThickness = 20,
                    Rotation = 45,
                    Children = new Drawable[]{
                        new Box{
                            RelativeSizeAxes = Axes.Both,
                            Alpha = 0,
                            AlwaysPresent = true
                        },
                        pathArrow = new Container{
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Rotation = -45,
                            Child = new PathPlayerArrow()
                        }
                    }
                },
                maskedArrow = new Container{
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(.5f),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.White,
                    BorderThickness = 10,
                    Rotation = 45,
                    Child = new MaksedPlayerArrow{
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = -45
                    }
                }
            };

            setArrowSkin(ArrowStyle.Pointy);
        }

        public bool CanBeHit(DrawableHishigataHitObject hitObject) => hitObject.HitObject.Lane == (int)lastAction;

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            float maximumDankness = 15 * amplitudes.Average;
            rContainer.MoveToOffset(new Vector2(RNG.NextSingle(-maximumDankness, maximumDankness), RNG.NextSingle(-maximumDankness, maximumDankness)), 50).Then().MoveTo(new Vector2(0), 100);
            gContainer.MoveToOffset(new Vector2(RNG.NextSingle(-maximumDankness, maximumDankness), RNG.NextSingle(-maximumDankness, maximumDankness)), 50).Then().MoveTo(new Vector2(0), 100);
            bContainer.MoveToOffset(new Vector2(RNG.NextSingle(-maximumDankness, maximumDankness), RNG.NextSingle(-maximumDankness, maximumDankness)), 50).Then().MoveTo(new Vector2(0), 100);
        }

        private HishigataAction lastAction = HishigataAction.Up;
        public bool OnPressed(HishigataAction action)
        {
            FinishTransforms();
            float FacingAngle = action.ToAngle();

            this.ScaleTo(new Vector2(1.1f), 50).Then().ScaleTo(1, 50);
            rotateToClosestEquivalent(FacingAngle, action.IsOppositeTo(lastAction) ? 100 : 50);

            lastAction = action;
            return true;
        }
        public void OnReleased(HishigataAction action) { }

        private void rotateToClosestEquivalent(float angle, double duration = 0, Easing easing = Easing.None)
        {
            float difference = (angle - angleBindable.Value) % 360;
            if (difference > 180) difference -= 360;
            else if (difference < -180) difference += 360;

            double totalDuration = Math.Abs(difference) / 90 * duration;

            this.TransformBindableTo(angleBindable, angleBindable.Value + difference, totalDuration, easing);
        }

        private void setArrowSkin (ArrowStyle style)
        {
            maskedArrow.Alpha = 0;
            pathArrow.Alpha = 0;

            if ( style == ArrowStyle.Pointy )
                maskedArrow.Alpha = 1;
            else
                pathArrow.Alpha = 1;
        }

        private Bindable<ArrowStyle> arrowStyleBindable = new Bindable<ArrowStyle>();

        [BackgroundDependencyLoader]
        private void load (HishigataSettingsManager config)
        {
            arrowStyleBindable.ValueChanged += x => setArrowSkin(x.NewValue);
            config.BindWith(HishigataSetting.ArrowStyle, arrowStyleBindable);
            setArrowSkin(arrowStyleBindable.Value);
        }
    }
}
