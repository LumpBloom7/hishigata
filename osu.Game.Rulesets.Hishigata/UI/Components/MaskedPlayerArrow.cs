using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using System;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class MaskedPlayerArrow : CompositeDrawable
    {
        private readonly Box chevron;
        private readonly Container rotationContainer;

        public MaskedPlayerArrow()
        {
            RelativeSizeAxes = Axes.Both;
            Size = new Vector2(.5f);
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Masking = true;
            BorderColour = Color4.White;
            BorderThickness = 10;
            Rotation = 45;
            InternalChild = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Rotation = -45,
                Child = rotationContainer = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = chevron = new Box
                    {
                        Size = new Vector2(70.72f, 35.36f),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.BottomCentre,
                        Alpha = 0,
                        AlwaysPresent = true
                    }
                }
            };
        }

        public void ChangeRotation(float newRotation, Easing easing = Easing.None)
        {
            FinishTransforms(true);
            float difference = (newRotation - rotationContainer.Rotation) % 360;
            if (difference > 180) difference -= 360;
            else if (difference < -180) difference += 360;

            if (Math.Abs(difference) == 180)
            {
                chevron.MoveToY(35.36f, 50, easing).Then().MoveToY(0);
                rotationContainer.Delay(50).RotateTo(newRotation);
            }
            else
            {
                rotationContainer.RotateTo(newRotation, 50, easing);
            }
        }
    }
}
