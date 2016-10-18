using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stateMachine
{
    internal enum State
    {
        NN, LL, UU, PP, LM, UM, PM,
        ZU, UZ
    }

    internal enum Trigger
    {
        _N, L_, U_, P_, _L, _U, _P,
        _M,
        _Z, Z_
    }

    public class DumpStatus
    {
        #region instance
        /*
        static DumpStatus _instance = null;
        public static DumpStatus Instance { get { return (_instance == null) ? newInstance() : _instance; } }
        static DumpStatus newInstance()
        {
            _instance = new DumpStatus();
            return _instance;
        }
        */
        #endregion

        public string Current { get { return GetCurrentState(); } }
        string GetCurrentState()
        {
            switch (_stateMachine.State)
            {
                case State.LL: return "LL";
                case State.UU: return "UU";
                case State.PP: return "PP";
                case State.PM: return "PM";
                case State.UM: return "UM";
                case State.LM: return "LM";
                default: return "NN";
            }
        }

        StateMachine<State, Trigger> _stateMachine;
        public DumpStatus()
        {
            _stateMachine = new StateMachine<State, Trigger>(State.NN);    
            DefaultConfiguration();
        }
         
        internal void AddFragment(string fragment)
        {
            string s = "";        
            //                                   
            //_stateMachine.NewAction(Trigger.P_);
            //_stateMachine.NewAction(Trigger._L);
            //_stateMachine.NewAction(Trigger._L);
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            s += string.Format("{0}\t{1}", "Trigger.U_", _stateMachine.NewAction(Trigger.U_));
            s += string.Format("{0}\t{1}", "Trigger.L_", _stateMachine.NewAction(Trigger.L_));
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            //s += _stateMachine.NewAction(Trigger._L);
            //s += _stateMachine.NewAction(Trigger._U);
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            s += string.Format("{0}\t{1}", "Trigger._L", _stateMachine.NewAction(Trigger._L));
            s += string.Format("{0}\t{1}", "Trigger._P", _stateMachine.NewAction(Trigger._P));
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            s += string.Format("{0}\t{1}", "Trigger._U", _stateMachine.NewAction(Trigger._U));
            s += string.Format("{0}\t{1}", "Trigger._U", _stateMachine.NewAction(Trigger._U));
            s += string.Format("{0}\t{1}", "Trigger._P", _stateMachine.NewAction(Trigger._P));
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            s += string.Format("{0}\t{1}", "Trigger._U", _stateMachine.NewAction(Trigger._U));
            s += string.Format("{0}\t{1}", "Trigger._M", _stateMachine.NewAction(Trigger._M));
            s += string.Format("{0}\t{1}", "Trigger._P", _stateMachine.NewAction(Trigger._P));

            Console.WriteLine(s);
        }

        public void OnExcavator()
        {
            _stateMachine.NewAction(Trigger._L);
        }
        public void OnDepot()
        {
            _stateMachine.NewAction(Trigger._U);
        }
        public void OnParking()
        {
            _stateMachine.NewAction(Trigger._P);
        }
        public void OnRoad()
        {
            _stateMachine.NewAction(Trigger._M);
        }

        /// <summary>
        /// temp
        /// </summary>
        void DefaultConfiguration()
        {
            _stateMachine.Configure(State.LL).Permit(Trigger.L_, State.LM, OutFrom);
            _stateMachine.Configure(State.LM).Permit(Trigger._U, State.UU);
            _stateMachine.Configure(State.UU).Permit(Trigger.U_, State.UM, OutFrom);
            _stateMachine.Configure(State.UM).Permit(Trigger._L, State.LL);
            _stateMachine.Configure(State.UM).Permit(Trigger._P, State.PP);
            _stateMachine.Configure(State.PP).Permit(Trigger.P_, State.PM, OutFrom);
            _stateMachine.Configure(State.PM).Permit(Trigger._L, State.LL);
            //
            _stateMachine.Configure(State.LL).Permit(Trigger._M, State.NN, DoRoad);
            _stateMachine.Configure(State.UU).Permit(Trigger._M, State.NN, DoRoad);
            _stateMachine.Configure(State.PP).Permit(Trigger._M, State.NN, DoRoad);
            _stateMachine.Configure(State.NN).Permit(Trigger._M, State.NN, DoRoad);
            //                                                    
            /*                     
            _stateMachine.Configure(State.LM).Permit(Trigger._Z, State.ZU);
            _stateMachine.Configure(State.UM).Permit(Trigger._Z, State.ZU);
            _stateMachine.Configure(State.ZU).Permit(Trigger._U, State.UU);
            _stateMachine.Configure(State.ZU).Permit(Trigger.L_, State.LM);
            _stateMachine.Configure(State.ZU).Permit(Trigger.U_, State.UM);
            _stateMachine.Configure(State.UU).Permit(Trigger.Z_, State.UZ, OutFrom);
            _stateMachine.Configure(State.UZ).Permit(Trigger.U_, State.UM);
            */
        }

        private bool OutFrom(State state, Trigger trigger)
        {
            return DoRoad(state, trigger);
        }
               
        private bool DoRoad(State state, Trigger trigger)
        {
            if (trigger != Trigger._M)
                return false;
            switch (state)
            {
                case State.LL:
                    _stateMachine.NewAction(Trigger.L_);
                    break;
                case State.UU:
                    _stateMachine.NewAction(Trigger.U_);
                    break;
                case State.PP:
                case State.NN:
                    _stateMachine.NewAction(Trigger.P_);
                    break;
                default:
                    return false;
            }
            return true;                        
        }
    }
}
