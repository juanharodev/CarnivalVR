using FSM;
using UnityEngine;

[CreateAssetMenu(fileName ="HasArrived",menuName ="FSM/Fish/Conditions/HasArrived")]
public class HasArrived : Condition
{
    public float minArriveDistance;
    public override bool Check(StateMachine stateMachine)
    {
        return stateMachine.Agent.remainingDistance < minArriveDistance || !stateMachine.Agent.hasPath; 
    }
}