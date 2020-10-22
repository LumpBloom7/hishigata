using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using osu.Framework.Bindables;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class MaksedPlayerArrow : Container
    {
        private readonly Box chevron;

        public MaksedPlayerArrow ()
        {
            Child = chevron = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Size = new Vector2(2f),
                Anchor = Anchor.Centre,
                Origin = Anchor.BottomCentre,
                Alpha = 0,
                AlwaysPresent = true
            };
        }

        [BackgroundDependencyLoader]
        private void load (Bindable<float> angleBindable)
        {
            angleBindable.ValueChanged += (x) => chevron.Rotation = x.NewValue;
            chevron.Rotation = angleBindable.Value;
        }
    }
}
