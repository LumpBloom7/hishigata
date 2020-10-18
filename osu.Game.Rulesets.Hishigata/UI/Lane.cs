using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class Lane : Playfield
    {
        private readonly Container hitExplosionContainer;
        public Lane(int ID = 0)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddRangeInternal(new Drawable[]{
                hitExplosionContainer = new Container(),
                HitObjectContainer,
                new LaneReceptor{ID = ID}
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

        public class LaneReceptor : CompositeDrawable
        {
            public int ID { get; set; }
            private HishigataInputManager hishigataInputManager;
            internal HishigataInputManager HishigataActionInputManager => hishigataInputManager ??= GetContainingInputManager() as HishigataInputManager;

            public override bool HandlePositionalInput => true;

            public LaneReceptor()
            {
                Position = new Vector2(0, -70);
                Size = new Vector2(70, 1000);

                Anchor = Anchor.Centre;
                Origin = Anchor.BottomCentre;
                Alpha = 0;
                AlwaysPresent = true;
            }

            private TouchSource? touchMemory;

            protected override bool OnTouchDown(TouchDownEvent e)
            {
                if (ReceivePositionalInputAt(e.ScreenSpaceTouchDownPosition) && !touchMemory.HasValue)
                {
                    touchMemory = e.Touch.Source;
                    HishigataActionInputManager.TriggerPressed(HishigataAction.Up + ID);
                    return true;
                }
                return base.OnTouchDown(e);
            }

            protected override void OnTouchUp(TouchUpEvent e)
            {
                if (touchMemory.HasValue && e.Touch.Source == touchMemory.Value)
                {
                    touchMemory = null;
                    HishigataActionInputManager.TriggerReleased(HishigataAction.Up + ID);
                }
            }
        }
    }
}
