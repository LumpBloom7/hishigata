using System;
using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Rulesets.Hishigata.Judgements;
using osu.Game.Rulesets.Judgements;
using osu.Game.Utils;

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

        private class BonusHitSampleInfo : HitSampleInfo, IEquatable<BonusHitSampleInfo>
        {
            private const string lookup_name = "Gameplay/catch-banana";

            public override IEnumerable<string> LookupNames
            {
                get
                {
                    yield return lookup_name;
                }
            }

            public BonusHitSampleInfo(int volume = 0)
                : base(string.Empty, volume: volume)
            {
            }

            public override HitSampleInfo With(Optional<string> newName = default, Optional<string?> newBank = default, Optional<string?> newSuffix = default, Optional<int> newVolume = default)
                => new BonusHitSampleInfo(newVolume.GetOr(Volume));

            public bool Equals(BonusHitSampleInfo? other)
                => other != null;

            public override bool Equals(object? obj)
                => obj is BonusHitSampleInfo other && Equals(other);

            public override int GetHashCode() => lookup_name.GetHashCode();
        }
    }
}
