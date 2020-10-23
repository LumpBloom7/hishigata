using osu.Framework.Graphics.Containers;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using osu.Framework.Bindables;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class MaskedPlayerArrow : CompositeDrawable
    {
        private readonly Box chevron;

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
                Child = chevron = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(2f),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.BottomCentre,
                    Alpha = 0,
                    AlwaysPresent = true
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(BindableFloat angleBindable)
        {
            angleBindable.BindValueChanged(a => chevron.Rotation = a.NewValue, true);
        }
    }
}
