﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisScoreboardBackend;

namespace TennisScoreboardUnitTests
{
    [TestClass]
    public class SetUnitTests
    {
        private Player firstPlayer = new Player("eli");
        private Player secondPlayer = new Player("yael");

        [TestMethod]
        public void AddScoreLinearTest()
        {
            Set set = new Set(firstPlayer, secondPlayer);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set.AddScore(firstPlayer);
                }
                if (i == 5)
                {
                    Assert.AreEqual("win", set.AddScore(firstPlayer));
                }
                Assert.AreEqual((i +1).ToString(), set.AddScore(firstPlayer));
            }
        }
        [TestMethod]
        public void AddScoreEdgeCase()
        {
            Set set = new Set(firstPlayer, secondPlayer);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    set.AddScore(firstPlayer);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set.AddScore(secondPlayer);
                }
                if (i == 6)
                {
                    Assert.AreEqual("win", set.AddScore(secondPlayer));
                }
                Assert.AreEqual((i + 1).ToString(), set.AddScore(secondPlayer));
            }
        }

        [TestMethod]
        public void resetScore()
        {
            Set set = new Set(firstPlayer, secondPlayer);
            for (int i = 0; i < 10; i++)
            {
                set.AddScore(firstPlayer);
            }
            for (int i = 0; i < 10; i++)
            {
                set.AddScore(secondPlayer);
            }
            set.ResetScore();
            Assert.AreEqual("0", set.AddScore(firstPlayer), false, "Reset score did not return zero");
            Assert.AreEqual("0", set.AddScore(secondPlayer), false, "Reset score did not return zero");
        }
    }
}