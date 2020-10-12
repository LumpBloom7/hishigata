
using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Rhombus
{
    public class RhombusInputManager : RulesetInputManager<RhombusAction>
    {
        public RhombusInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }
    }

    public enum RhombusAction
    {
        [Description("Button 1")]
        Button1,

        [Description("Button 2")]
        Button2,
    }
}
