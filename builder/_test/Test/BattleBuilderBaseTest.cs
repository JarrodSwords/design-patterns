using DesignPatterns.Builder.Domain;
using Xunit;

namespace DesignPatterns.Builder.Test
{
    public abstract class BattleBuilderBaseTest
    {
        #region Core

        protected BattleBuilderBaseTest()
        {
            Director = new BattleDirector();
        }

        #endregion

        #region Public Interface

        public BattleDirector Director { get; }

        #endregion

        #region Test Methods

        [Fact]
        public abstract void WhenConfiguringRandomEncounter_ReturnValidBattle();

        [Fact]
        public abstract void WhenConfiguringTutorial_ReturnValidBattle();

        #endregion
    }
}
