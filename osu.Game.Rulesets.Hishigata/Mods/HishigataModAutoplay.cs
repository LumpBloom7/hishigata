using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Scoring;
using osu.Game.Users;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModAutoplay : ModAutoplay
    {
        public override Score CreateReplayScore(IBeatmap beatmap, IReadOnlyList<Mod> mods) => new Score
        {
            ScoreInfo = new ScoreInfo { User = new User { Username = "Hishi" } },
            Replay = new HishigataAutoGenerator(beatmap).Generate(),
        };
    }
}
