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
            if (effectPoint.KiaiMode && (beatIndex % Math.Max((int)(timingPoint.BPM / 80), 1)) == 0)
            {
                Add(new Effect(timingPoint.BeatLength)
                {
                    Colour = new Color4(RNG.NextSingle(.5f), RNG.NextSingle(.5f), RNG.NextSingle(.5f), 1),
                });
            }
        }

        public class Effect : CompositeDrawable
        {
            private double animDuration;
            public override bool RemoveWhenNotAlive => base.RemoveWhenNotAlive;

            public Effect(double duration)
            {
                animDuration = duration;
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
                this.ScaleTo(3, animDuration).FadeOut(animDuration * 2).Expire(true);
            }
        }
    }
}
