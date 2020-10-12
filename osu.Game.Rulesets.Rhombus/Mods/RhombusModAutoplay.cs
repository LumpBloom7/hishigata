
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Rhombus.Objects;
using osu.Game.Rulesets.Rhombus.Replays;
using osu.Game.Scoring;
using osu.Game.Users;

namespace osu.Game.Rulesets.Rhombus.Mods
{
    public class RhombusModAutoplay : ModAutoplay<RhombusHitObject>
    {
        public override Score CreateReplayScore(IBeatmap beatmap) => new Score
        {
            ScoreInfo = new ScoreInfo
            {
                User = new User { Username = "sample" },
            },
            Replay = new RhombusAutoGenerator(beatmap).Generate(),
        };
    }
}
