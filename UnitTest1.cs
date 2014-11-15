using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneAliveCellWith1AliveNeighboursDies()
        {
            var cell = new Cell();
            cell.AddNeighbour(new Cell());

            cell.Mutate();
            Assert.IsFalse(cell.IsAlive());
        }

        [TestMethod]
        public void OneAliveCellWith2AliveNeighboursDies()
        {
            var cell = new Cell();
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());

            cell.Mutate();
            Assert.IsTrue(cell.IsAlive());
        }

        [TestMethod]
        public void OneDeadCellWith2AliveNeighboursStayDead()
        {
            var cell = new Cell(CellState.Dead);
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());

            cell.Mutate();
            Assert.IsFalse(cell.IsAlive());
        }

        [TestMethod]
        public void OneDeadCellWith3AliveCellBecomesAlive()
        {
            var cell = new Cell(CellState.Dead);
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());

            cell.Mutate();
            Assert.IsTrue(cell.IsAlive());
        }

        [TestMethod]
        public void OneDeadCellWith3AliveCellStaysAlive()
        {
            var cell = new Cell();
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());
            cell.AddNeighbour(new Cell());

            cell.Mutate();
            Assert.IsTrue(cell.IsAlive());
        }
    }
}
