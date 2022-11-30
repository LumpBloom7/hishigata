using NUnit.Framework;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Hishigata.Tests
{
    [TestFixture]
    public partial class TestSceneHishigataPlayer : PlayerTestScene
    {
        protected override Ruleset CreatePlayerRuleset() => new HishigataRuleset();
    }
}
