using osu.Game.Tests.Visual;
using NUnit.Framework;

namespace osu.Game.Rulesets.Hishigata.Tests
{
    [TestFixture]
    public class TestSceneHishigataPlayer : PlayerTestScene
    {
        protected override Ruleset CreatePlayerRuleset() => new HishigataRuleset();
    }
}
