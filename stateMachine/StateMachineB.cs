using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    public partial class StateMachine<TState, TTrigger>
    {                                               
        private IDictionary<TState, StateRepresentation> _stateConfiguration = new Dictionary<TState, StateRepresentation>();
        private TState _state;
        private TState _nullState;

        public TState State { get { return _state; } }

        public StateMachine(TState initialState)
        {
            _state = initialState;
            _nullState = _state;
            Configure(_nullState);
        }         

        StateRepresentation GetRepresentation(TState state)
        {
            StateRepresentation result;

            if (!_stateConfiguration.TryGetValue(state, out result))
            {
                result = new StateRepresentation(state);
                _stateConfiguration.Add(state, result);
                //Configure(_state).Permit(_firstTrigger, state);
            }                       
            return _stateConfiguration[state];
        }

        public StateConfiguration Configure(TState state)
        {
            return new StateConfiguration(this, GetRepresentation(state));
        }

        public string NewAction(TTrigger trigger)
        {
            var source = _state;
            var representativeState = GetRepresentation(source);
            _state = representativeState.Execute(trigger);

            return string.Format("{0} -> {1}\n", source, _state);
        }    

    }

}
