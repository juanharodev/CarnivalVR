using FSM;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName ="FishFlee",menuName ="FSM/Fish/States/FishFlee")]
public class FishFlee : State
{
    public override void Enter(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");
        
        stateMachine.Agent.speed = fishBoard.fleeSpeed;

        fishBoard.scareCount++;

        Vector3 fleeDir = (stateMachine.transform.position - fishBoard.fishNet.transform.position).normalized;
        Vector3 fleeTargetPos = stateMachine.transform.position + (fleeDir * fishBoard.fleeRadius);

        fishBoard.fishAgent.SetDestination(fleeTargetPos);
        if(NavMesh.SamplePosition(fleeTargetPos,out NavMeshHit hit, fishBoard.posSampleDistance, NavMesh.AllAreas))
        {
            stateMachine.Agent.SetDestination(hit.position);
        }
        
        fishBoard.fearTime = Time.time + fishBoard.fleeDuration;
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
