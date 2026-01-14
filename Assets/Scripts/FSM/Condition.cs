using UnityEngine;

namespace FSM
{
        public abstract class Condition : ScriptableObject
    {
        public abstract bool Check(StateMachine stateMachine);
    }
}