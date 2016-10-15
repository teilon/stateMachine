using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    public partial class StateMachine<TState, TTrigger>
    {
        public class StateConfiguration
        {
            private readonly StateMachine<TState, TTrigger> _machine;
            readonly StateRepresentation _representation;     

            internal StateConfiguration(    StateMachine<TState, TTrigger> machine, 
                                            StateRepresentation representation  )
            {
                _machine = machine;
                _representation = representation;                
            }

            public StateConfiguration Permit(TTrigger trigger, TState destinationState)
            {   
                return Permit(trigger, destinationState, (x,y) => false);
            }                                             

            public StateConfiguration Permit(TTrigger trigger, TState destinationState, Func<TState, TTrigger, bool> action)
            {
                if (!_representation.TriggerBehaviours.ContainsKey(trigger))
                {
                    StateRepresentation sr = _machine.GetRepresentation(_machine._nullState);
                    sr.AddTriggerBehaviour(new TransitioningTriggerBehaviour(trigger, destinationState, action));
                }
                _representation.AddTriggerBehaviour(new TransitioningTriggerBehaviour(trigger, destinationState, action));
                return this;
            }  
        }
    }
}