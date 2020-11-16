using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Rulesets.Hishigata.Judgements;
using osu.Game.Rulesets.Judgements;

namespace osu.Game.Rulesets.Hishigata.Objects
{
    public class HishigataBonus : HishigataHitObject
    {
        private static readonly List<HitSampleInfo> samples = new List<HitSampleInfo> { new BonusHitSampleInfo() };

        public HishigataBonus()
        {
            Samples = samples;
        }

        public override Judgement CreateJudgement() => new HishigataBonusJudgement();

        private class BonusHitSampleInfo : HitSampleInfo
        {
            private static string[] lookupNames { get; } = { "metronomelow", "catch-banana" };

            public override IEnumerable<string> LookupNames => lookupNames;
        }
    }
}
