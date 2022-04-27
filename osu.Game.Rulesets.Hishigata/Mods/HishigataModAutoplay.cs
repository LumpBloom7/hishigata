using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Hishigata.Replays;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Hishigata.Mods
{
    public class HishigataModAutoplay : ModAutoplay
    {
        public override ModReplayData CreateReplayData(IBeatmap beatmap, IReadOnlyList<Mod> mods)
            => new ModReplayData(new HishigataAutoGenerator(beatmap).Generate(), new ModCreatedUser { Username = "Hishi" });
    }
}
