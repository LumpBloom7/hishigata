using System;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.Objects.Drawables
{
    public class DrawableHishigataClap : DrawableHishigataHitObject
    {
        public new HishigataNote HitObject => (HishigataNote)base.HitObject;

        protected Container Note;

        public DrawableHishigataClap() : base(null)
        {
        }

        public DrawableHishigataClap(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            AddInternal(Note = new Container
            {
                Position = new Vector2(0, -300),
                Size = new Vector2(50),
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
                Child = new SpriteIcon
                {
                    RelativeSizeAxes = Axes.Both,
                    Icon = FontAwesome.Solid.ChevronDown,
                }
            });
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
        }

        protected override void UpdateInitialTransforms()
        {
        }

        protected override void UpdateHitStateTransforms(ArmedState state)
        {
        }
    }
}
