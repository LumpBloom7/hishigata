using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Difficulty.Preprocessing;
using osu.Game.Rulesets.Difficulty.Skills;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Hishigata.Difficulty
{
    public class HishigataDifficultyCalculator(IRulesetInfo ruleset, IWorkingBeatmap beatmap) : DifficultyCalculator(ruleset, beatmap)
    {
        protected override DifficultyAttributes CreateDifficultyAttributes(IBeatmap beatmap, Mod[] mods, Skill[] skills)
        {
            int maxCombo = 0;
            foreach (HishigataHitObject h in beatmap.HitObjects)
            {
                if (h is not HishigataBonus) ++maxCombo;
            }

            return new DifficultyAttributes
            {
                StarRating = beatmap.BeatmapInfo.StarRating * 1f, // Inflate SR of converts, to encourage players to try lower diffs, without hurting their fragile ego.
                Mods = mods,
                MaxCombo = maxCombo
            };
        }

        protected override IEnumerable<DifficultyHitObject> CreateDifficultyHitObjects(IBeatmap beatmap, Mod[] mods) => [];

        protected override Skill[] CreateSkills(IBeatmap beatmap, Mod[] mods) => [];
    }
}
