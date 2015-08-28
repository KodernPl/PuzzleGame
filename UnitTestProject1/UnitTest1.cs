using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// "Invariant tests 0"
        /// </summary>
        [TestMethod]
        public void InvariantTests0()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 4,2,3,7 }, { 8,5,6,10 }, { 9,1,0,11 }, { 12,13,14,15 } });
            bool result = puzzle.LowerRowInvariant(2,2);
            Assert.AreEqual(true, result, "Test #0 invariant test");
            string move = puzzle.SolveInteriorTile(2, 2);
            result = puzzle.LowerRowInvariant(2, 1);
            Assert.AreEqual(true, result, "Test #1 invariant test");
            Assert.AreEqual(move, "urullddruld", "Test #2 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 1"
        /// </summary>
        [TestMethod]
        public void InvariantTest1()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 4, 2, 3, 7 }, { 8, 5, 6, 1 }, { 9, 10, 0, 11 }, { 12, 13, 14, 15 } });
            bool result = puzzle.LowerRowInvariant(2, 2) ;
            Assert.AreEqual(true, result, "Test #3 invariant test");
            string move = puzzle.SolveInteriorTile(2, 2);
            result = puzzle.LowerRowInvariant(2, 1);
            Assert.AreEqual(true, result, "Test #4 invariant test");
            Assert.AreEqual(move, "l", "Test #5 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 2"
        /// </summary>
        [TestMethod]
        public void InvariantTest2()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {10,2,3,7 }, { 8,5,4,1 }, { 9,6,0,11 }, { 12,13,14,15 } });
            bool result = puzzle.LowerRowInvariant(2, 2) ;
            Assert.AreEqual(true, result, "Test #6 invariant test");
            string move = puzzle.SolveInteriorTile(2, 2);
            result = puzzle.LowerRowInvariant(2, 1);
            Assert.AreEqual(true, result, "Test #7 invariant test");
            Assert.AreEqual(move, "uulldrruldrulddruld", "Test #8 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 3"
        /// </summary>
        [TestMethod]
        public void InvariantTest3()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 3,2,10,7 }, { 8,5,4,1 }, { 9,6,0,11 }, { 12,13,14,15 } });
            bool result = puzzle.LowerRowInvariant(2, 2);
            Assert.AreEqual(true, result, "Test #9 invariant test");
            string move = puzzle.SolveInteriorTile(2, 2);
            Assert.AreEqual(move, "uulddruld", "Test #11 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 4"
        /// </summary>
        [TestMethod]
        public void InvariantTest4()
        {
            Puzzle puzzle = new Puzzle(3, 3, new int[,] { { 8, 7, 6 }, { 5, 4, 3 }, { 2, 1, 0 }});
            bool result = puzzle.LowerRowInvariant(2, 2);
            Assert.AreEqual(true, result, "Test #18  invariant test");
            string move = puzzle.SolveInteriorTile(2, 2);
            Assert.AreEqual(move, "uulldrruldrulddruld", "Test #20 solve_interior test");
            move = puzzle.SolveInteriorTile(2, 1);
            Assert.AreEqual(move, "uulddruld", "Test #22 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 5"
        /// </summary>
        [TestMethod]
        public void InvariantTest5()
        {
            Puzzle puzzle = new Puzzle(3, 3, new int[,] { { 3, 2, 1 }, { 6, 5, 4 }, { 0, 7, 8 } });
            bool result = puzzle.LowerRowInvariant(2, 0);
            Assert.AreEqual(true, result, "Test #26  invariant test");

            string move = puzzle.SolveCol0Tile(2);
            Assert.AreEqual(move, "urr", "Test #28 solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 6"
        /// </summary>
        [TestMethod]
        public void InvariantTest6()
        {
            Puzzle puzzle = new Puzzle(3, 3, new int[,] { { 2, 1, 5 }, { 4, 3, 6 }, { 0, 7, 8 } });
            bool result = puzzle.LowerRowInvariant(2, 0);
            Assert.AreEqual(true, result, "Test #29  invariant test");

            string move = puzzle.SolveCol0Tile(2);
            Assert.AreEqual(move, "urrulldruldrdlurdluurddlurr", "Test #31solve_interior test");
        }

        /// <summary>
        /// "Invariant tests 7"
        /// </summary>
        [TestMethod]
        public void InvariantTest7()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 3,2,10,7 }, { 8,5,4,1 }, { 9,6,12,11 }, { 0,13,14,15 } });
            bool result = puzzle.LowerRowInvariant(3, 0);
            Assert.AreEqual(true, result, "Test #32  invariant test");

            string move = puzzle.SolveCol0Tile(3);
            Assert.AreEqual(move, "urrulldruldrdlurdluurddlurrr", "Test #31solve_interior test");
        }

        /// <summary>
        /// "Row1Invariant 8"
        /// </summary>
        [TestMethod]
        public void Row1InvariantTest8()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {4,6,1,3 }, { 5,2,0,7 }, { 8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row1Invariant(2);
            Assert.AreEqual(true, result, "Test #35  Row1Invariant");
        }

        /// <summary>
        /// "Row0Invariant 9"
        /// </summary>
        [TestMethod]
        public void Row0InvariantTest9()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {4,2,0,3}, { 5,1,6,7}, { 8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row0Invariant(2);
            Assert.AreEqual(true, result, "Test #36  Row0Invariant");
        }

        /// <summary>
        /// "SolveRow1Tile 1"
        /// </summary>
        [TestMethod]
        public void SolveRow1TileTest10()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {4,2,1,3}, {5,6,7,0 }, {8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row1Invariant(3);
            Assert.AreEqual(true, result, "Test #37  Row1Invariant");
            string move = puzzle.SolveRow1Tile(3);
            Assert.AreEqual(move, "lur", "Test #38  SolveRow1Tile");
        }
    
        /// <summary>
        /// "SolveRow1Tile 11"
        /// </summary>
        [TestMethod]
        public void SolveRow1TileTest11()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {4,6,1,7}, {5,2,3,0 }, {8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row1Invariant(3);
            Assert.AreEqual(true, result, "Test #39  Row1Invariant");
            string move = puzzle.SolveRow1Tile(3);
           
        }
    
        /// <summary>
        /// "SolveRow1Tile 12"
        /// </summary>
        [TestMethod]
        public void SolveRow1TileTest12()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {7,6,4,1}, {5,2,3,0 }, {8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row1Invariant(3);
            Assert.AreEqual(true, result, "Test #40  Row1Invariant");
        }
        
        /// <summary>
        /// "SolveRow0Tile 13"
        /// </summary>
        [TestMethod]
        public void SolveRow1TileTest13()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { {3,1,6,0}, {4,2,5,7 }, {8,9,10,11 }, { 12,13,14,15 } });
            bool result = puzzle.Row0Invariant(3);
            Assert.AreEqual(true, result, "Test #41  Row0Invariant");
            string move = puzzle.SolveRow0Tile(3);
            //move = puzzle.SolveRow1Tile(2);
           // move = puzzle.SolveRow0Tile(2);
           // move = puzzle.Solve2x2();
        }
    
        /// <summary>
        /// "SolveInterior 15 must fail"
        /// </summary>
        [TestMethod]
        public void SolveInterior15()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] 
                { { 4, 2, 5, 6 },
                  { 12, 7, 8, 3 }, 
                  { 9, 14, 15, 0 }, 
                  { 13, 10, 11, 1 } });
          
            string move = puzzle.SolveInteriorTile(3, 3);
            Assert.AreEqual(move, "duldruld", "Test #485 " + move);

            move = puzzle.SolveInteriorTile(3, 2);
            Assert.AreEqual(move, "uldruld", "Test #486 " + move);

            move = puzzle.SolveInteriorTile(3, 1);
            Assert.AreEqual(move, "l", "Test #487 " + move);

            move = puzzle.SolveCol0Tile(3);
            Assert.AreEqual(move, "uurdlruldrdlurdluurddlurrrr", "Test #488 " + move);

            move = puzzle.SolveInteriorTile(2, 3);
            Assert.AreEqual(move, "l", "Test #489");

            move = puzzle.SolveInteriorTile(2, 2);
            Assert.AreEqual(move, "l", "Test #490");

            move = puzzle.SolveInteriorTile(2, 1);
            Assert.AreEqual(move, "uld", "Test #491");

            move = puzzle.SolveCol0Tile(2);
            Assert.AreEqual(move, "urrulldruldrdlurdluurddlurrr", "Test #492");

            move = puzzle.SolveRow1Tile(3);
            Assert.AreEqual(move, "ullldrruldrruldru", "Test #493");

            move = puzzle.SolveRow0Tile(3);
            Assert.AreEqual(move, "lduldruldurdlurrdluldrruld", "Test #494");
            
            move = puzzle.SolveRow1Tile(3);
            Assert.AreEqual(move, "lur", "Test #495");

            move = puzzle.SolveRow0Tile(3);
            Assert.AreEqual(move, "ld", "Test #496");

            move = puzzle.Solve2x2();
            Assert.AreEqual(move, "lu", "Test #497");
        }

        /// <summary>
        /// "CheclSolvedAll"
        /// </summary>
        [TestMethod]
        public void CheckSolvedAll()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } });
            bool result = puzzle.CheckSolvedAll();
            Assert.AreEqual(true, result, "Test #50  Checksolvd");
        }

        /// <summary>
        /// "CheclSolved"
        /// </summary>
        [TestMethod]
        public void CheckSolved()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } });
            bool result = puzzle.CheckSolved(0,0);
            Assert.AreEqual(true, result, "Test #51  Checksolvd");
        }

        /// <summary>
        /// "CheclSolved1"
        /// </summary>
        [TestMethod]
        public void CheckSolved1()
        {
            Puzzle puzzle = new Puzzle(4, 4, new int[,] { { 0, 1, 3, 2 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } });
            bool result = puzzle.CheckSolved(0, 0);
            Assert.AreEqual(false, result, "Test #52  Checksolvd");
        }

        /// <summary>
        /// "SolvePuzzle4x4 random"
        /// </summary>
        [TestMethod]
        public void SolvePuzzleTest1()
        {
            for(int idx = 0;idx<10;idx++)
            {
            Puzzle puzzle = new Puzzle(4, 4);
            bool result = puzzle.CheckSolved(0, 0);
            Assert.AreEqual(false, result, "Should be not solved. Test: "+idx);
            puzzle.SolvePuzzle();
            result = puzzle.CheckSolved(0, 0);
            Assert.AreEqual(true, result, "Should be solved Test: " + idx);
            }

        }

        /// <summary>
        /// "SolvePuzzle5x5 random"
        /// </summary>
        [TestMethod]
        public void SolvePuzzleTest2()
        {
            for (int idx = 0; idx < 10; idx++)
            {
                Puzzle puzzle = new Puzzle(5, 5);
                bool result = puzzle.CheckSolved(0, 0);
                Assert.AreEqual(false, result, "Should be not solved Test: " + idx);
                puzzle.SolvePuzzle();
                result = puzzle.CheckSolved(0, 0);
                Assert.AreEqual(true, result, "Should be solved Test: " + idx);
            }

        }
    }
}
