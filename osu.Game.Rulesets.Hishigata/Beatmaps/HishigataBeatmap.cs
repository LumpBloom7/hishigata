using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Hishigata.Localisation;
using osu.Game.Rulesets.Hishigata.Objects;

namespace osu.Game.Rulesets.Hishigata.Beatmaps
{
    public class HishigataBeatmap : Beatmap<HishigataHitObject>
    {
        public override IEnumerable<BeatmapStatistic> GetStatistics()
        {
            int notes = 0;
            int feigns = 0;
            int bonus = 0;

            foreach (var h in HitObjects)
            {
                switch (h)
                {
                    case HishigataBonus _:
                        ++bonus;
                        break;
                    case HishigataNote n:
                        if (n.IsFeign) ++feigns;
                        else ++notes;
                        break;
                }
            }

            float total = Math.Max(1, notes + feigns + bonus);

            return new[]
            {
                new BeatmapStatistic
                {
                    Name = HishigataBeatmapStrings.NoteCount,
                    Content = notes.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Circles),
                    BarDisplayLength = notes / total,
                },
                new BeatmapStatistic
                {
                    Name = HishigataBeatmapStrings.FeignCount,
                    Content = feigns.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Circles),
                    BarDisplayLength = feigns / total,
                },
                new BeatmapStatistic
                {
                    Name = HishigataBeatmapStrings.BonusCount,
                    Content = bonus.ToString(),
                    CreateIcon = () => new BeatmapStatisticIcon(BeatmapStatisticsIconType.Spinners),
                    BarDisplayLength = bonus / total,
                },
            };
        }
    }
}
