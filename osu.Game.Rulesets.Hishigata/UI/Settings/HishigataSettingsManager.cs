using System;
using System.Collections.Generic;
using System.Text;
using osu.Game.Configuration;
using osu.Game.Rulesets.Configuration;

namespace osu.Game.Rulesets.Hishigata.UI.Settings
{
    public class HishigataSettingsManager : RulesetConfigManager<HishigataSetting>
    {
        public HishigataSettingsManager (SettingsStore settings, RulesetInfo ruleset, int? variant = null) : base(settings, ruleset, variant)
        {
            Set(HishigataSetting.ArrowStyle,ArrowStyle.Round);

            base.InitialiseDefaults();
        }
    }
}
