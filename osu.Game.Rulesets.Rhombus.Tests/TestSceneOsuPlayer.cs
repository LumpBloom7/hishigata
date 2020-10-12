using osu.Game.Tests.Visual;
using NUnit.Framework;

namespace osu.Game.Rulesets.Rhombus.Tests
{
    [TestFixture]
    public class TestSceneRhombusPlayer : PlayerTestScene
    {
        protected override Ruleset CreatePlayerRuleset() => new RhombusRuleset();
    }
}
