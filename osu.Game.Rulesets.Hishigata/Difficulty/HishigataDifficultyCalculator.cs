using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Difficulty.Preprocessing;
using osu.Game.Rulesets.Difficulty.Skills;
using osu.Game.Rulesets.Hishigata.Objects;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Hishigata.Difficulty
{
    public class HishigataDifficultyCalculator : DifficultyCalculator
    {
        public HishigataDifficultyCalculator(Ruleset ruleset, WorkingBeatmap beatmap) : base(ruleset, beatmap) { }

        protected override DifficultyAttributes CreateDifficultyAttributes(IBeatmap beatmap, Mod[] mods, Skill[] skills, double clockRate)
        {
            int maxCombo = 0;
            foreach (HishigataHitObject h in beatmap.HitObjects)
            {
                if (!(h is HishigataBonus)) ++maxCombo;
            }

            return new DifficultyAttributes
            {
                StarRating = beatmap.BeatmapInfo.StarRating * 1f, // Inflate SR of converts, to encourage players to try lower diffs, without hurting their fragile ego.
                Mods = mods,
                Skills = skills,
                MaxCombo = maxCombo
            };
        }

        protected override IEnumerable<DifficultyHitObject> CreateDifficultyHitObjects(IBeatmap beatmap, double clockRate) => Array.Empty<DifficultyHitObject>();

        protected override Skill[] CreateSkills(IBeatmap beatmap, Mod[] mods, double clockRate) => Array.Empty<Skill>();
    }
}
