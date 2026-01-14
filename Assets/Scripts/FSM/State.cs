namespace FSM
{

    public abstract class State : UnityEngine.ScriptableObject
    {
        public System.Collections.Generic.List<Transition> transitions;

        public abstract void Enter(StateMachine stateMachine);
        public abstract void Exit(StateMachine stateMachine);
        public abstract void FrameUpdate(StateMachine stateMachine);
        public abstract void PhysicUpdate();

        public virtual void CheckTransitions(StateMachine stateMachine)
        {
            foreach (Transition transition in transitions)
            {
                if (transition.condition != null && transition.condition.Check(stateMachine))
                {
                    stateMachine.ChangeState(transition.state);
                    break;
                }
            }
        }
    }    
}