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
                    Anchor= Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderColour = Color4.White,
                    BorderThickness = 20,
                    Rotation= 45,
                    Children = new Drawable[]{
                        new Box{
                            RelativeSizeAxes = Axes.Both,
                            Alpha= 0,
                            AlwaysPresent = true
                        },
                        new Container{
                            Anchor = Anchor.Centre,
                            Origin =Anchor.Centre,
                            Rotation = -45,
                            Child = new PlayerArrow()
                        }
                    }
                },
            };
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

        private TransformSequence<PlayerVisual> rotateToClosestEquivalent(float angle, double duration = 0, Easing easing = Easing.None)
        {
            float difference = (angle - angleBindable.Value) % 360;
            if (difference > 180) difference -= 360;
            else if (difference < -180) difference += 360;

            return this.TransformBindableTo(angleBindable, angleBindable.Value + difference, duration, easing);
        }
    }
}
