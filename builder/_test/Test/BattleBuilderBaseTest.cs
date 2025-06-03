using CreationalPatterns.Builder.Domain;
using Xunit;

namespace CreationalPatterns.Builder.Test
{
    public abstract class BattleBuilderBaseTest
    {
        #region Setup

        protected BattleBuilderBaseTest()
        {
            Director = new BattleDirector();
        }

        #endregion

        #region Implementation

        public BattleDirector Director { get; }

        #endregion

        #region Requirements

        [Fact]
        public abstract void WhenConfiguringRandomEncounter_ReturnValidBattle();

        [Fact]
        public abstract void WhenConfiguringTutorial_ReturnValidBattle();

        #endregion
    }
}
