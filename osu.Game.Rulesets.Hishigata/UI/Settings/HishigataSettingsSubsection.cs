using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Configuration;

namespace osu.Game.Rulesets.Hishigata.UI.Settings
{
    public class HishigataSettingsSubsection : RulesetSettingsSubsection
    {
        public HishigataSettingsSubsection (Ruleset ruleset) : base(ruleset) { }

        protected override string Header => "Hishigata";

        [BackgroundDependencyLoader]
        private void load ()
        {
            var config = Config as HishigataSettingsManager;

            Children = new Drawable[] {
                new SettingsEnumDropdown<ArrowStyle> {
                    LabelText = "Arrow style",
                    Current = config.GetBindable<ArrowStyle>(HishigataSetting.ArrowStyle)
                }
            };
        }
    }
}
