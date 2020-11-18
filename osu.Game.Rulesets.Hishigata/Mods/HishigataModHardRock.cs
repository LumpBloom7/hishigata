using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModHardRock : ModHardRock, IApplicableToHitObject
    {
        public override double ScoreMultiplier => 1.06;
        public override bool Ranked => true;

        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is HishigataLanedHitObject hishiObj)
            {
                if (hishiObj.Lane == 0) hishiObj.Lane = 2;
                else if (hishiObj.Lane == 2) hishiObj.Lane = 0;
            }
        }
    }
}
