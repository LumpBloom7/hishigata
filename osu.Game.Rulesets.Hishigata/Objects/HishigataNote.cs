using System;
using osu.Framework.Bindables;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataNote : HishigataHitObject
    {
        public bool IsFeign { get; set; }
    }
}
