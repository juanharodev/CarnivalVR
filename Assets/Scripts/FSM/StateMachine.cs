using UnityEngine;
using UnityEngine.AI;

namespace FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class StateMachine : MonoBehaviour{
    public State CurrentState { get; private set; }
    [SerializeField] State initialState;
    public UnityEngine.AI.NavMeshAgent Agent{get; private set;}

    public BlackBoard blackBoard;

    void Awake()
    {
        blackBoard = new BlackBoard();
        if(Agent == null){Agent = GetComponent<NavMeshAgent>();}
    }

    void Start()
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