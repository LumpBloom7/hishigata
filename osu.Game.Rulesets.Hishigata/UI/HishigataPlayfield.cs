﻿using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.UI.Components;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI
{
    [Cached]
    public partial class HishigataPlayfield : Playfield
    {
        private HishigataInputManager hishigataActionInputManager = null!;
        internal HishigataInputManager HishigataActionInputManager => hishigataActionInputManager ??= (HishigataInputManager)GetContainingInputManager();

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

        private readonly List<Lane> lanes = new List<Lane>();
        private Container playfieldContainer = null!;

        [Cached]
        private PlayerVisual playerObject = null!;

        public HishigataPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            AddRangeInternal(new Drawable[]{
                new EffectContainer(),
                new Container
                {
                    Size = new Vector2(113.137f),
                    Rotation = 45,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    BorderThickness = 2,
                    BorderColour = Color4.LightGray,
                    Child = new Box
                    {
                        Alpha = 0,
                        RelativeSizeAxes = Axes.Both,
                        AlwaysPresent = true
                    }
                },
                new Rhombus().With(x => x.Add(playfieldContainer = new Container
                {
                    Rotation = -45,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = playerObject = new PlayerVisual()
                }))
            });

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
            var hishiObj = (HishigataHitObject)hitObject;
            lanes[hishiObj.Lane].Add(hitObject);
        }

        private int? touchedLane;

        protected override void Update()
        {
            base.Update();

            var touchInput = HishigataActionInputManager.CurrentState.Touch;

            if (touchInput.ActiveSources.Any())
            {
                var focusedTouch = touchInput.GetTouchPosition(touchInput.ActiveSources.Last())!;
                float TouchAngle = ToScreenSpace(OriginPosition).GetDegreesFromPosition(focusedTouch.Value);

                for (int i = 0; i < 4; ++i)
                {
                    if (Math.Abs(HishigataExtensions.GetDeltaAngle(TouchAngle, i * 90)) <= 45)
                    {
                        if (!touchedLane.Equals(i))
                        {
                            if (touchedLane.HasValue)
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
