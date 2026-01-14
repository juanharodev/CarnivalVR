using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="FishFear",menuName ="FSM/Fish/States/FishFear")]
public class FishFear : State
{
    public override void Enter(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");
        fishBoard.fearTime = Time.time + fishBoard.fearDuration;
        stateMachine.Agent.speed = fishBoard.fearSpeed;
    }

    public override void Exit(StateMachine stateMachine)
    {
    }

    public override void FrameUpdate(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");
        
        if(fishBoard.nextFearUpdate< Time.time)
        {
            float netDistance = Vector3.Distance(fishBoard.fishNet.transform.position,
                        stateMachine.transform.position);
            bool isNetFar = fishBoard.netScareDistance < netDistance;
            bool isNetSlow = fishBoard.fishNet.CurrentSpeed < fishBoard.netScareSpeed;
            if(isNetFar && isNetSlow)
            {
                fishBoard.scareCount--;
            }
            
            fishBoard.nextFearUpdate += 1;

            Vector3 fleeDir = (stateMachine.transform.position - fishBoard.fishNet.transform.position).normalized;
            Vector3 fleeTargetPos = stateMachine.transform.position + (fleeDir * fishBoard.fleeRadius);

            fishBoard.fishAgent.SetDestination(fleeTargetPos);
        }  
    }

    public override void PhysicUpdate()
    {
    }
}