using osu.Game.Configuration;
using osu.Game.Rulesets.Configuration;

namespace osu.Game.Rulesets.Hishigata.Configuration
{
    public class HishigataRulesetConfigManager : RulesetConfigManager<HishigataRulesetSettings>
    {
        public HishigataRulesetConfigManager(SettingsStore settings, RulesetInfo ruleset, int? variant = null)
            : base(settings, ruleset, variant) { }

        protected override void InitialiseDefaults()
        {
            base.InitialiseDefaults();

            SetDefault(HishigataRulesetSettings.ArrowStyle, ArrowStyle.Sharp);
        }
    }

    public enum HishigataRulesetSettings
    {
        ArrowStyle
    }
}
