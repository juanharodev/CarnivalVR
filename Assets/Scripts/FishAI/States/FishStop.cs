using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="FishStop",menuName ="FSM/Fish/States/FishStop")]
public class FishStop : State
{
    
    public override void Enter(StateMachine stateMachine)
    {
        stateMachine.blackBoard.GetValue<FishBoard>("fish_board").SetNextMoveTime();
        stateMachine.Agent.SetDestination(stateMachine.transform.position);
    }

    public override void Exit(StateMachine stateMachine)
    {
    }

    public override void FrameUpdate(StateMachine stateMachine)
    {
    }

    public override void PhysicUpdate()
    {
    }
}