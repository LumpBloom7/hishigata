
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Rhombus.Objects.Drawables
{
    public class DrawableRhombusHitObject : DrawableHitObject<RhombusHitObject>
    {
        public DrawableRhombusHitObject(RhombusHitObject hitObject)
            : base(hitObject)
        {
            Size = new Vector2(40);
            Origin = Anchor.Centre;

            // todo: add visuals.
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (timeOffset >= 0)
                // todo: implement judgement logic
                ApplyResult(r => r.Type = HitResult.Perfect);
        }

        protected override void UpdateStateTransforms(ArmedState state)
        {
            const double duration = 1000;

            switch (state)
            {
                case ArmedState.Hit:
                    this.FadeOut(duration, Easing.OutQuint).Expire();
                    break;

                case ArmedState.Miss:

                    this.FadeColour(Color4.Red, duration);
                    this.FadeOut(duration, Easing.InQuint).Expire();
                    break;
            }
        }
    }
}
