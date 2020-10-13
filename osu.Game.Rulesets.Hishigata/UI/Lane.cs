using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.Judgements;
using static osu.Game.Input.Handlers.ReplayInputHandler;
using osuTK;
using System.Linq;
using osu.Framework.Input.Bindings;
using osu.Framework.Allocation;
using osu.Game.Rulesets.UI.Scrolling;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class Lane : Playfield
    {
        private readonly Container hitExplosionContainer;
        public Lane()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddInternal(hitExplosionContainer = new Container());
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
