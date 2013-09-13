using BowlingFinal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Test
    {
        private Game _g;

        private void Setup()
        {
            _g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                _g.Roll(pins);
        }

        private void RollSpare()
        {
            _g.Roll(5);
            _g.Roll(5);
        }

        private void RollStrike()
        {
            _g.Roll(10);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            Setup();
            RollMany(20,0);
            Assert.AreEqual(0, _g.Score());
        }

        [TestMethod]
        public void TestRollAllOnes()
        {
            Setup();
            RollMany(20, 1);
            Assert.AreEqual(20, _g.Score());
        }

        [TestMethod]
        public void TestRollOneSpare()
        {
            Setup();
            RollSpare();
            _g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _g.Score());
        }

        [TestMethod]
        public void TestRollOneStrike()
        {
            Setup();
            RollStrike();
            _g.Roll(3);
            _g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, _g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            Setup();
            RollMany(12, 10);
            Assert.AreEqual(300, _g.Score());
        }
    }
}
