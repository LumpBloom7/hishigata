using osu.Framework.Input.Bindings;
using osu.Framework.Localisation;
using osu.Game.Rulesets.Hishigata.Localisation;
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
        [LocalisableDescription(typeof(HishigataActionStrings), nameof(HishigataActionStrings.Up))]
        Up,

        [LocalisableDescription(typeof(HishigataActionStrings), nameof(HishigataActionStrings.Right))]
        Right,

        [LocalisableDescription(typeof(HishigataActionStrings), nameof(HishigataActionStrings.Down))]
        Down,

        [LocalisableDescription(typeof(HishigataActionStrings), nameof(HishigataActionStrings.Left))]
        Left,
    }
}
