using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public partial class Rhombus : BeatSyncedContainer
    {
        public Rhombus()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.None;
            Size = new Vector2(450);
            Rotation = 45;
            Masking = true;
            BorderColour = Color4.Gray;
            BorderThickness = 10;
            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Hollow = true,
                Radius = 20,
                Colour = Color4.Gray,
            };
            Child = new Box
            {
                Colour = Color4.Black,
                RelativeSizeAxes = Axes.Both,
                Alpha = .8f
            };

            kiaiBindable.BindValueChanged(updateGlowState, true);
        }

        private BindableBool kiaiBindable = new BindableBool();

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            kiaiBindable.Value = effectPoint.KiaiMode;
            float expandSize = 5 * amplitudes.Average * (effectPoint.KiaiMode ? 2 : 1);

            FinishTransforms(false, nameof(Size));
            this.ResizeTo(450 + expandSize, 100).Then().ResizeTo(450, 50);
        }

        private void updateGlowState(ValueChangedEvent<bool> value)
        {
            if (value.NewValue)
                FadeEdgeEffectTo(1, 100);
            else
                FadeEdgeEffectTo(0, 200);
        }
    }
}
