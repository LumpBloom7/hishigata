using System;
using osu.Framework.Audio.Track;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Pooling;
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
        private DrawablePool<Effect> effectPool;
        public EffectContainer()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.None;
            Rotation = 45;
            AddInternal(effectPool = new DrawablePool<Effect>(5));
        }

        private float accumulator;
        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, ChannelAmplitudes amplitudes)
        {
            int MainBeatInterval = Math.Max((int)(timingPoint.BPM / 80), 1);
            accumulator += MainBeatInterval / 2f;

            bool isMainBeat = (beatIndex % MainBeatInterval) == 0;
            bool isSubBeat = accumulator > 1;
            accumulator %= 1;

            if (effectPoint.KiaiMode)
            {
                if (isMainBeat)
                    Add(effectPool.Get(e => e.Apply(timingPoint.BeatLength, MainBeatInterval, true)));
                else if (isSubBeat)
                    Add(effectPool.Get(e => e.Apply(timingPoint.BeatLength)));
            }
        }

        public class Effect : PoolableDrawable
        {
            public Effect()
            {
                Size = new Vector2(450);
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
                RelativeSizeAxes = Axes.None;
                Masking = true;
                BorderThickness = 5;
                InternalChild = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                };
            }

            private double duration;
            private double durationMultiplier;

            public void Apply(double duration, double durationMultiplier = 1, bool hasBackgroundColor = false)
            {
                this.duration = duration;
                this.durationMultiplier = durationMultiplier;

                var newColor = Color4Extensions.FromHSV(RNG.NextSingle(360), 1, 1);
                BorderColour = newColor.Opacity(.6f);
                InternalChild.Colour = hasBackgroundColor ? newColor.Opacity(.2f) : Color4.Transparent;
            }

            protected override void PrepareForUse()
            {
                base.PrepareForUse();
                this.ScaleTo(1).ScaleTo(6 * (float)durationMultiplier, duration * 2 * durationMultiplier).FadeOutFromOne(duration * 2 * durationMultiplier).Expire(true);
            }
        }
    }
}
