namespace GoL
{
    using System.Collections.Generic;
    using System.Linq;

    public class NextStateTranslator
    {
        private Dictionary<CurrentStateTranslationConditionDto, CellState> _stateTranslations 
            = new Dictionary<CurrentStateTranslationConditionDto, CellState>();

        public NextStateTranslator()
        {
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Alive, count => count < 2), CellState.Dead);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Dead, count => count < 2), CellState.Dead);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Alive, count => count == 2), CellState.Alive);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Dead, count => count == 2), CellState.Dead);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Alive, count => count == 3), CellState.Alive);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Dead, count => count == 3), CellState.Alive);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Alive, count => count > 3), CellState.Dead);
            _stateTranslations.Add(new CurrentStateTranslationConditionDto(CellState.Dead, count => count > 3), CellState.Dead);
        }

        public CellState Translate(CellState currentState, int aliveNeighbours)
        {
            var translationKey = _stateTranslations.Keys.First(
                k => k.CurrentState == currentState && k.CanApplyOnAliveNeighbours(aliveNeighbours));

            return _stateTranslations[translationKey];
        }
    }
}
