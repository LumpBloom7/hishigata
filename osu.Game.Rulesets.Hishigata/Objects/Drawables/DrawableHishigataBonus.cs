using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataBonus : DrawableHishigataHitObject
    {

        public DrawableHishigataBonus() : this(null)
        { }

        public DrawableHishigataBonus(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
            Colour = Color4.Gold;
        }
    }
}
