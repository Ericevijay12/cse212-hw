using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace week03.code
{
    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        public void Maze_Basic()
        {
            Dictionary<(int, int), bool[]> map = SetupMazeMap();
            var maze = new Maze(map);
            Assert.AreEqual("Current location (x=1, y=1)", maze.GetStatus());

            AssertThrowsInvalidOperationException(maze.MoveUp);
            AssertThrowsInvalidOperationException(maze.MoveLeft);

            maze.MoveRight();
            AssertThrowsInvalidOperationException(maze.MoveRight);

            maze.MoveDown();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();
            maze.MoveRight();
            maze.MoveUp();
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveLeft();
            AssertThrowsInvalidOperationException(maze.MoveDown);

            maze.MoveRight();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();

            Assert.AreEqual("Current location (x=6, y=6)", maze.GetStatus());
        }

        private void AssertThrowsInvalidOperationException(Action action)
        {
            try
            {
                action();
                Assert.Fail("Exception should have been thrown.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Can't go that way!", e.Message);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception e)
            {
                Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
            }
        }

        private static Dictionary<(int, int), bool[]> SetupMazeMap()
        {
            return new Dictionary<(int, int), bool[]> {
                { (1, 1), new[] { false, true, false, true } },
                { (1, 2), new[] { false, true, true, false } },
                { (1, 3), new[] { false, false, false, false } },
                { (1, 4), new[] { false, true, false, true } },
                { (1, 5), new[] { false, false, true, true } },
                { (1, 6), new[] { false, false, true, false } },
                { (2, 1), new[] { true, false, false, true } },
                { (2, 2), new[] { true, false, true, true } },
                { (2, 3), new[] { false, false, true, true } },
                { (2, 4), new[] { true, true, true, false } },
                { (2, 5), new[] { false, false, false, false } },
                { (2, 6), new[] { false, false, false, false } },
                { (3, 1), new[] { false, false, false, false } },
                { (3, 2), new[] { false, false, false, false } },
                { (3, 3), new[] { false, false, false, false } },
                { (3, 4), new[] { true, true, false, true } },
                { (3, 5), new[] { false, false, true, true } },
                { (3, 6), new[] { false, false, true, false } },
                { (4, 1), new[] { false, true, false, false } },
                { (4, 2), new[] { false, false, false, false } },
                { (4, 3), new[] { false, true, false, true } },
                { (4, 4), new[] { true, true, true, false } },
                { (4, 5), new[] { false, false, false, false } },
                { (4, 6), new[] { false, false, false, false } },
                { (5, 1), new[] { true, true, false, true } },
                { (5, 2), new[] { false, false, true, true } },
                { (5, 3), new[] { true, true, true, true } },
                { (5, 4), new[] { true, false, true, true } },
                { (5, 5), new[] { false, false, true, true } },
                { (5, 6), new[] { false, true, true, false } },
                { (6, 1), new[] { true, false, false, false } },
                { (6, 2), new[] { false, false, false, false } },
                { (6, 3), new[] { true, false, false, false } },
                { (6, 4), new[] { false, false, false, false } },
                { (6, 5), new[] { false, false, false, false } },
                { (6, 6), new[] { true, false, false, false } }
            };
        }
    }
}
