using System;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Bindings;
using osu.Framework.Utils;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.Configuration;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class Rhombus : BeatSyncedContainer
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
            Child = new Box
            {
                Colour = Color4.Black,
                RelativeSizeAxes = Axes.Both,
                Alpha = .8f
            };
        }

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            if (effectPoint.KiaiMode)
            {
                FinishTransforms();
                this.ResizeTo(454.5f, 100).Then().ResizeTo(450, 50);
            }
        }
    }
}
