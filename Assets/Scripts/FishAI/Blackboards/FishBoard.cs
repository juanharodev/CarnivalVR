using FSM;
using UnityEngine;

public class FishBoard : MonoBehaviour
{
    [Header("Speed")]
    public float idleSpeed;
    public float fleeSpeed;
    public float fearSpeed;

    [Header("References")]
    public FishNet fishNet; 
    public FishAgent fishAgent;
    [SerializeField] StateMachine fsm;
    
    [Header("Fear")]
    public float netScareSpeed;
    public float netScareDistance; 

    [Header("Timers")]   
    public float fearDuration;
    public float fearTime; 
    public float fleeDuration;
    public float nextFearUpdate;
    public int scareCount;
    public int scaresBeforeAfraid;
   

    [Header("Movement")]
    public float fleeRadius;
    public float posSampleDistance;


    
    [Header("Stoped delay")]
    public float minDelay;
    public float maxDelay;
    [HideInInspector] public float nextMoveTime;
    public void SetNextMoveTime(){nextMoveTime = Time.time + Random.Range(minDelay,maxDelay);}



    void Awake()
    {
        fsm.blackBoard.SetValue<FishBoard>("fish_board",this);
    }


}