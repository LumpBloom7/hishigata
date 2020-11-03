using System;
using osu.Framework.Audio.Track;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Utils;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class EffectContainer : BeatSyncedContainer
    {
        public EffectContainer()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.None;
            Rotation = 45;
        }

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            int MainBeatInterval = Math.Max((int)(timingPoint.BPM / 80), 1);
            if (effectPoint.KiaiMode && (beatIndex % MainBeatInterval) == 0)
            {
                Add(new Effect(timingPoint.BeatLength, timingPoint.BeatLength * MainBeatInterval)
                {
                    Colour = new Color4(RNG.NextSingle(.5f), RNG.NextSingle(.5f), RNG.NextSingle(.5f), 1),
                });
            }
            else if (effectPoint.KiaiMode)
            {
                Add(new LineEffect(timingPoint.BeatLength)
                {
                    Colour = new Color4(RNG.NextSingle(.5f), RNG.NextSingle(.5f), RNG.NextSingle(.5f), 1),
                });
            }
        }

        public class LineEffect : CompositeDrawable
        {
            private readonly double animDuration;

            public override bool RemoveWhenNotAlive => base.RemoveWhenNotAlive;

            public LineEffect(double duration)
            {
                animDuration = duration;
                Size = new Vector2(450);
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
                Masking = true;
                BorderThickness = 5;
                BorderColour = Color4.White;
                RelativeSizeAxes = Axes.None;
                Alpha = .8f;
                InternalChild = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    AlwaysPresent = true,
                    Alpha = 0,
                };
            }

            protected override void LoadComplete()
            {
                this.ScaleTo(3, animDuration).FadeOut(animDuration * 2).Expire(true);
            }
        }

        public class Effect : CompositeDrawable
        {
            private readonly double animDuration;
            private readonly double fadeDuration;

            public override bool RemoveWhenNotAlive => base.RemoveWhenNotAlive;

            public Effect(double duration, double FadeOut)
            {
                animDuration = duration;
                fadeDuration = FadeOut;

                Size = new Vector2(450);
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
                RelativeSizeAxes = Axes.None;
                Alpha = .4f;
                InternalChild = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                };
            }

            protected override void LoadComplete()
            {
                this.ScaleTo(3, animDuration).FadeOut(fadeDuration * 2).Expire(true);
            }
        }
    }
}
