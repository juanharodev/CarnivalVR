using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="IsScared",menuName ="FSM/Fish/Conditions/IsScared")]
public class IsScared : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");
        float netDistance = Vector3.Distance(stateMachine.transform.position,
                                            fishBoard.fishNet.transform.position);
        bool isNetClose = netDistance < fishBoard.netScareDistance;
        bool isNetFast = fishBoard.netScareSpeed < fishBoard.fishNet.CurrentSpeed;
        return isNetClose || isNetFast;
    }
}