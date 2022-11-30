using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public partial class MaskedPlayerArrow : CompositeDrawable
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
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = chevron = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        RelativePositionAxes = Axes.Both,
                        // Using the hypotenuse length
                        Size = new Vector2(1.41f, 0.71f),
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
            if (Math.Abs(newRotation - rotationContainer.Rotation) == 180)
            {
                chevron.MoveToY(0.71f, 50, easing).Then().MoveToY(0);
                rotationContainer.Delay(50).RotateTo(newRotation);
            }
            else
            {
                rotationContainer.RotateTo(newRotation, 50, easing);
            }
        }
    }
}
