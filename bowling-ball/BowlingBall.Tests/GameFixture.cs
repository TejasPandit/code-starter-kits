using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        IGame game;

        [TestInitialize]
        public void Setup()
        {
            game = SetupGame(); ;
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            // ACT
            RollPins(game, 20, 0);
            // ASSERT
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_One_test()
        {
            // ACT
            RollPins(game, 20, 1);

            // ASSERT
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_Spare_test()
        {
            // ACT
            RollSpare(game);
            game.Roll(3);
            RollPins(game, 17, 0);

            // ASSERT
            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_Strike_test()
        {
            // ACT
            RollSpike(game);
            game.Roll(3);
            game.Roll(4);
            RollPins(game, 16, 0);

            // ASSERT
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_With_Perfect_Game_test()
        {
            // ACT
            RollPins(game, 12, 10);

            // ASSERT
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_With_Random_Game_test()
        {
            // ACT
            game.Roll(3);
            game.Roll(5); //8
            game.Roll(4); //12
            game.Roll(5); //17
            game.Roll(2); //19
            game.Roll(4); //23
            game.Roll(6); //29
            game.Roll(1); //30
            RollSpike(game); //40
            

            // ASSERT
            Assert.AreEqual(40, game.GetScore());
        }


        #region Private Methods
        private void RollSpike(IGame game)
        {
            game.Roll(10);
        }


        private void RollSpare(IGame game)
        {
            game.Roll(5);
            game.Roll(5);
        }



        private Game SetupGame()
        {
            return new Game();
        }

        private void RollPins(IGame game, int numberOfRolls, int pinHitsPerRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                game.Roll(pinHitsPerRoll);
            }
        }

        #endregion Private Methods        
    }
}
