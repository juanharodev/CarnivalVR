using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="FishIdle",menuName ="FSM/Fish/States/FishIdle")]
public class FishIdle : State
{
    public override void Enter(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");
        stateMachine.Agent.speed = fishBoard.idleSpeed;

        fishBoard.fishAgent.SetRandomDestination();
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