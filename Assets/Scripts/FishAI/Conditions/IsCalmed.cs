using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="IsCalmed",menuName ="FSM/Fish/Conditions/IsCalmed")]
public class IsCalmed : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        return stateMachine.blackBoard.GetValue<FishBoard>("fish_board").fearTime < Time.time;
    }
}