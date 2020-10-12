
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Rhombus.UI
{
    [Cached]
    public class RhombusPlayfield : ScrollingPlayfield
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                HitObjectContainer,
            });
        }
    }
}
