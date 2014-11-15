namespace GoL
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    
    public class Cell
    {
        private NextStateTranslator _computeNextState = new NextStateTranslator();
        private List<Cell> _neighbours;

        public Cell(CellState etat = CellState.Alive)
        {
            State = etat;
            _neighbours = new List<Cell>();
        }

        public CellState State { get; private set; }

        public void AddNeighbour(Cell cellule)
        {
            _neighbours.Add(cellule);
        }

        public bool IsAlive()
        {
            return State == CellState.Alive;
        }

        public void Mutate()
        {
            var aliveNeighbours = _neighbours.Count(v => v.State == CellState.Alive);
            State = _computeNextState.Translate(State, aliveNeighbours);
        }
    }
}
