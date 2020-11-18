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
    public class DrawableHishigataHitObject : DrawableHitObject<HishigataHitObject>
    {
        public DrawableHishigataHitObject() : base(null)
        {
        }

        public DrawableHishigataHitObject(HishigataHitObject hitObject = null)
            : base(hitObject)
        {
        }
    }
}
