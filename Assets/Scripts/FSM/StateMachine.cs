using UnityEngine;
using UnityEngine.AI;

namespace FSM
{
    [RequireComponent(typeof(NavMeshAgent)),DefaultExecutionOrder(-2)]
    public class StateMachine : MonoBehaviour{
    public State CurrentState { get; private set; }
    [SerializeField] State initialState;
    public State InitialState{get => initialState;}
    [SerializeField] UnityEngine.AI.NavMeshAgent agent;
    public UnityEngine.AI.NavMeshAgent Agent{get => agent; private set =>  agent = value;}

    public BlackBoard blackBoard;

    void Awake()
    {
        blackBoard = new BlackBoard();
        if(Agent == null){Agent = GetComponent<NavMeshAgent>();}
    }

    void OnEnable()
    {
        ChangeState(initialState);
    }


    public void ChangeState(State state)
    {
        if (CurrentState == state || state == null) { return; }

        if (CurrentState != null)
        {
            CurrentState.Exit(this);
        }
        CurrentState = state;
        CurrentState.Enter(this);
    }

    void Update()
    {
        CurrentState.FrameUpdate(this);
        CurrentState.CheckTransitions(this);
    }

    }
}