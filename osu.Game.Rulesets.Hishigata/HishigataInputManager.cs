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

    public static class HishigataActionExtensions
    {
        public static float Angle (this HishigataAction direction)
            => direction switch
            {
                HishigataAction.Up => 0,
                HishigataAction.Right => 90,
                HishigataAction.Down => 180,
                HishigataAction.Left => 270,

                _ => 0
            };

        public static bool IsOppositeTo (this HishigataAction direction, HishigataAction other)
            => direction != other && ( direction.Angle() + other.Angle() ) % 180 == 0; // mod 180 makes sure they are on the same "line"
    }
}
