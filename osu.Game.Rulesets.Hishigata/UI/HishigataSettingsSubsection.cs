using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Hishigata.Configuration;

namespace osu.Game.Rulesets.Hishigata.UI
{
    public class HishigataSettingsSubsection : RulesetSettingsSubsection
    {
        public HishigataSettingsSubsection(Ruleset ruleset) : base(ruleset) { }

        protected override LocalisableString Header => "Hishigata";

        [BackgroundDependencyLoader]
        private void load()
        {
            var config = Config as HishigataRulesetConfigManager;

            Children = new Drawable[] {
                new SettingsEnumDropdown<ArrowStyle> {
                    LabelText = "Arrow style",
                    Current = config.GetBindable<ArrowStyle>(HishigataRulesetSettings.ArrowStyle)
                }
            };
        }
    }
}
