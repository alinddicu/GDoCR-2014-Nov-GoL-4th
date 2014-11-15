namespace GoL
{
    using System;

    public class CurrentStateTranslationConditionDto
    {
        public CurrentStateTranslationConditionDto(CellState currentState, Func<int, bool> canApplyOnAliveNeighbours)
        {
            CurrentState = currentState;
            CanApplyOnAliveNeighbours = canApplyOnAliveNeighbours;
        }
        public CellState CurrentState { get; private set; }

        public Func<int, bool> CanApplyOnAliveNeighbours { get; private set; }
    }
}


