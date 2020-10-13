using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.UI;
using static osu.Game.Input.Handlers.ReplayInputHandler;
using osuTK;
using System.Linq;
using osu.Framework.Input.Bindings;
using osu.Framework.Allocation;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class Lane : Playfield
    {
        public Lane()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }
    }
}
