using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="TimeToMove",menuName ="FSM/Fish/Conditions/TimeToMove")]
public class TimeToMove : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        FishBoard fishBoard = stateMachine.blackBoard.GetValue<FishBoard>("fish_board");

        return fishBoard.nextMoveTime < Time.time;
    }
}