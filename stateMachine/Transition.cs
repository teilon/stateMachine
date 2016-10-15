using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    public partial class StateMachine<TState, TTrigger>
    {
        public class Transition
        {
            readonly TState _source;
            readonly TState _destination;
            readonly TTrigger _trigger;

            public Transition(TState source, TState destination, TTrigger trigger)
            {
                _source = source;
                _destination = destination;
                _trigger = trigger;
            }

            public TState Source { get { return _source; } }
            public TState Destination { get { return _destination; } }
            public TTrigger Trigger { get { return _trigger; } }

            public bool IsReentry { get { return Source.Equals(Destination); } }
        }
    }
}
