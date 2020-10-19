using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Hishigata
{
    public class HishigataInputManager : RulesetInputManager<HishigataAction>
    {
        public HishigataInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }

        public void TriggerPressed(HishigataAction action) => KeyBindingContainer.TriggerPressed(action);
        public void TriggerReleased(HishigataAction action) => KeyBindingContainer.TriggerReleased(action);
    }

    public enum HishigataAction
    {
        [Description("Up")]
        Up,

        [Description("Right")]
        Right,

        [Description("Down")]
        Down,

        [Description("Left")]
        Left,
    }
}
