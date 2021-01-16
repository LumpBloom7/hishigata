using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Objects.Drawables;
using osu.Game.Rulesets.Hishigata.UI.Components;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI
{
    [Cached]
    public class HishigataPlayfield : Playfield
    {
        private HishigataInputManager hishigataActionInputManager;
        internal HishigataInputManager HishigataActionInputManager => hishigataActionInputManager ??= GetContainingInputManager() as HishigataInputManager;

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

        private readonly List<Lane> lanes = new List<Lane>();
        private Container playfieldContainer;

        [Cached]
        private PlayerVisual playerObject;

        public HishigataPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddInternal(new EffectContainer());
            AddInternal(new Rhombus().With(x => x.Add(playfieldContainer = new Container
            {
                Rotation = -45,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Child = playerObject = new PlayerVisual()
            })));

            for (int i = 0; i < 4; ++i)
            {
                var lane = new Lane
                {
                    Rotation = 90 * i
                };
                lanes.Add(lane);
                playfieldContainer.Add(lane);
                AddNested(lane);
            }
        }

        public override void Add(HitObject hitObject)
        {
            var hishiObj = hitObject as HishigataHitObject;
            lanes[hishiObj.Lane].Add(hitObject);
        }

        public override void Add(DrawableHitObject hitObject)
        {
            var hishigataObject = hitObject as DrawableHishigataHitObject;

            hishigataObject.CanBeHit = playerObject.CanBeHit;
            lanes[hishigataObject.HitObject.Lane].Add(hitObject);
        }

        private int? touchedLane;

        protected override void Update()
        {
            base.Update();

            var touchInput = HishigataActionInputManager.CurrentState.Touch;

            if (touchInput.ActiveSources.Any())
            {
                var focusedTouch = touchInput.GetTouchPosition(touchInput.ActiveSources.Last());
                var TouchCoord = ToLocalSpace(focusedTouch.Value);
                var TouchAngle = Vector2.Zero.GetDegreesFromPosition(TouchCoord);

                for (int i = 0; i < 4; ++i)
                {
                    if (Math.Abs(HishigataExtensions.GetDeltaAngle(TouchAngle, i * 90)) <= 45)
                    {
                        if (!touchedLane.Equals(i))
                        {
                            HishigataActionInputManager.TriggerReleased(HishigataAction.Up + touchedLane.Value);
                            HishigataActionInputManager.TriggerPressed(HishigataAction.Up + i);
                            touchedLane = i;
                        }
                        break;
                    }
                }
            }
            else
            {
                if (touchedLane.HasValue)
                    HishigataActionInputManager.TriggerReleased(HishigataAction.Up + touchedLane.Value);
                touchedLane = null;
            }
        }
    }
}
