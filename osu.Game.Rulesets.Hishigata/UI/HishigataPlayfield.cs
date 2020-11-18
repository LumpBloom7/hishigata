using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Pooling;
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
            })));
            playfieldContainer.Add(HitObjectContainer);
            playfieldContainer.Add(playerObject = new PlayerVisual());
            for (int i = 0; i < 4; ++i)
            {
                var lane = new Lane(i)
                {
                    Rotation = 90 * i
                };
                lanes.Add(lane);
                playfieldContainer.Add(lane);

                AddNested(lane);
            }
        }


        [BackgroundDependencyLoader]
        private void load()
        {
            registerPool<HishigataBonus, DrawableHishigataBonus>(2);
            registerPool<HishigataBonusTick, DrawableHishigataBonusTick>(2);
        }

        private void registerPool<TObject, TDrawable>(int initialSize, int? maximumSize = null)
            where TObject : HitObject
            where TDrawable : DrawableHitObject, new()
            => RegisterPool<TObject, TDrawable>(CreatePool<TDrawable>(initialSize, maximumSize));

        protected virtual DrawablePool<TDrawable> CreatePool<TDrawable>(int initialSize, int? maximumSize = null)
            where TDrawable : DrawableHitObject, new()
            => new DrawableHishigataPool<TDrawable>(playerObject.CanBeHit, playerObject.ContiguousRotationCount, initialSize, maximumSize);

        protected override HitObjectLifetimeEntry CreateLifetimeEntry(HitObject hitObject) => new HishigataHitObjectLifetimeEntry(hitObject);

        public override void Add(HitObject hitObject)
        {
            switch (hitObject)
            {
                case HishigataLanedHitObject hishigataLaned:
                    lanes[hishigataLaned.Lane].Add(hitObject);
                    break;
                case HishigataBonus _:
                    base.Add(hitObject);
                    break;
            }
        }

        public override void Add(DrawableHitObject hitObject)
        {
            switch (hitObject)
            {
                case DrawableHishigataLanedHitObject hishiLaned:
                    hishiLaned.CanBeHit = playerObject.CanBeHit;
                    lanes[hishiLaned.HitObject.Lane].Add(hitObject);
                    break;
            }
        }
    }
}
