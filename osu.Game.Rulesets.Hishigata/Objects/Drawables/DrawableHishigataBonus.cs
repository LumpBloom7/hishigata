using osu.Game.Rulesets.Objects.Drawables;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataBonus : DrawableHishigataHitObject
    {
        public DrawableHishigataBonus(HishigataHitObject hitObject)
            : base(hitObject)
        {
            Colour = Color4.Gold;
        }
    }
}
