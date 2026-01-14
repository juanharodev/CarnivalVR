using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="IsAfraid",menuName ="FSM/Fish/Conditions/IsAfraid")]
public class IsAfraid : Condition
{
    public override bool Check(StateMachine stateMachine)
    {

        FishBoard fishBoard =  stateMachine.blackBoard.GetValue<FishBoard>("fish_board");

        return fishBoard.scaresBeforeAfraid < fishBoard.scareCount;
    }
}