using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;
using System;

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

    public static class HishigataActionExtensions
    {
        public static float Angle(this HishigataAction direction) => (int)direction * 90;

        public static bool IsOppositeTo(this HishigataAction direction, HishigataAction other) => Math.Abs((int)direction - (int)other) == 2;
    }
}
