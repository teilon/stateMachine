using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal class StateRepresentation
        {
            private TState _state;
            private TState _tmpDestination;
            private readonly IDictionary<TTrigger, TriggerBehaviour> _triggerBehaviours = 
                new Dictionary<TTrigger, TriggerBehaviour>();
            internal IDictionary<TTrigger, TriggerBehaviour> TriggerBehaviours { get { return _triggerBehaviours; } }

            public StateRepresentation(TState state)
            {
                _state = state;
            }     

            public void AddTriggerBehaviour(TriggerBehaviour triggerBehaviour)
            {   
                TTrigger trigger = triggerBehaviour.Trigger;
                if (this.HasTrigger(trigger))
                {
                    _triggerBehaviours[trigger] = triggerBehaviour;
                    return;
                }
                _triggerBehaviours.Add(trigger, triggerBehaviour);     
            }
            
            bool HasTrigger(TTrigger trigger)
            {
                return (_triggerBehaviours.ContainsKey(trigger));
            }

            public TState Execute(TTrigger trigger)
            {
                TState _destination = _state;
                _tmpDestination = _destination;
                if (HasTrigger(trigger))
                {
                    TriggerBehaviour tb = _triggerBehaviours[trigger];
                    TransitioningTriggerBehaviour ttb = (TransitioningTriggerBehaviour)tb;
                    if (!ttb.Action(_state, trigger))
                    {
                        _destination = ttb.Destination;
                        _tmpDestination = _destination;
                    }                    
                }
                return _tmpDestination;
            }         

            public bool TryFindHandler(TTrigger trigger, out TriggerBehaviour handler)
            {                   
                if (HasTrigger(trigger))
                {
                    //handler = _triggerBehaviours[trigger];
                    //return true;
                }
                handler = null;
                return false;
            }
        }

    }
}
