using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class Lane : Playfield
    {
        private readonly Container hitExplosionContainer;
        public Lane()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddRangeInternal(new Drawable[]{
                hitExplosionContainer = new Container(),
                HitObjectContainer
            });
        }

        public override void Add(DrawableHitObject h)
        {
            h.OnNewResult += onNewResult;
            base.Add(h);
        }

        private void onNewResult(DrawableHitObject h, JudgementResult judgement)
        {
            if (judgement.IsHit)
                hitExplosionContainer.Add(new HitExplosion(h as DrawableHishigataHitObject));
        }
    }
}
