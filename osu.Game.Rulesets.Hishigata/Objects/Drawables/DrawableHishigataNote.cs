using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public partial class DrawableHishigataNote : DrawableHishigataHitObject
    {
        public new HishigataNote HitObject => (HishigataNote)base.HitObject;
        protected override double InitialLifetimeOffset => HitObject.TimePreempt + (HitObject.IsFeign ? 200 : 0);

        public DrawableHishigataNote() : this(null)
        {
        }

        public DrawableHishigataNote(HishigataHitObject? hitObject = null)
            : base(hitObject!)
        {
        }

        protected override void UpdateInitialTransforms()
        {
            LifetimeStart = HitObject.StartTime - InitialLifetimeOffset;
            if (HitObject.IsFeign)
            {
                Note.MoveTo(new Vector2(0, -190), HitObject.TimePreempt * .5).Then().Delay(200).MoveTo(new Vector2(0, -80), HitObject.TimePreempt * .5);
                this.RotateTo(180).FadeColour(Color4Extensions.FromHex("ff0064")).Delay(HitObject.TimePreempt * .5).Then().RotateTo(360, 200).FadeColour(Color4.White, 200);
            }
            else
                base.UpdateInitialTransforms();
        }
    }
}
