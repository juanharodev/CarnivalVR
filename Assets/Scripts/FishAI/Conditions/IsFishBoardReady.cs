using FSM;
using UnityEngine;

[CreateAssetMenu(fileName = "IsFishBoardReady", menuName = "FSM/Fish/Conditions/IsFishBoardReady ")]
public class IsFishBoardReady : Condition
{
    [SerializeField] string boardName;
    public override bool Check(StateMachine stateMachine)
    {
        return stateMachine.blackBoard.GetValue<FishBoard>(boardName) != null;
    }
}
