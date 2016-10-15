using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal abstract class TriggerBehaviour
        {
            private readonly TTrigger _trigger;
            private readonly Func<TState, TTrigger, bool> _action;

            public TTrigger Trigger { get { return _trigger; } }
            internal Func<TState, TTrigger, bool> Action { get { return _action; } }

            protected TriggerBehaviour(TTrigger trigger, Func<TState, TTrigger, bool> action)
            {
                _trigger = trigger;
                _action = action;
            }

            //protected void Run(TState state)
            //{
                //_action(state);
            //}

            public abstract bool ResultsInTransitionFrom(TState source, out TState destination);
            //public abstract bool ResultsInTransitionFrom(TState source, object[] args, out TState destination);
        }

        internal class TransitioningTriggerBehaviour : TriggerBehaviour
        {
            readonly TState _destination;
            internal TState Destination { get { return _destination; } }

            public TransitioningTriggerBehaviour(TTrigger trigger, TState destination, Func<TState, TTrigger, bool> action)
                : base(trigger, action)
            {
                _destination = destination;
            }
                        
            public override bool ResultsInTransitionFrom(TState source, out TState destination)
            {
                destination = _destination;
                return true;
            }                              
        }
    }
}
