using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)),DefaultExecutionOrder(-1)]
public class FishAgent : MonoBehaviour
{
    [Header("Navigation")]
    private NavMeshAgent agent;

    [Header("Model movement")]
    [SerializeField] Transform model;
    [SerializeField] float t;

    Vector3 modelDestination;

    [SerializeField] TankBounds tankBounds;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        MoveModel();
    }    

    public void SetDestination(Vector3 destination)
    {
        bool found = false;
        destination = tankBounds.ClampToBounds(destination);
        while (!found)
        {
            if(NavMesh.SamplePosition(destination,out NavMeshHit hit, 2f, NavMesh.AllAreas)){
                agent.SetDestination(hit.position);
                modelDestination = hit.position;
                modelDestination.y = tankBounds.GetRandomY();
                found = true;
            }
        }
    }

    public void SetRandomDestination()
    {
        SetDestination(tankBounds.GetRandomXZ());
    }

    [SerializeField] float modelTreshold = 1;
    void MoveModel()
    {
        Vector3 relativePos = modelDestination - model.transform.position;
        if(relativePos.magnitude < modelTreshold){relativePos = Vector3.Lerp(transform.forward,relativePos,Time.deltaTime);}
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        model.rotation = rotation;
        Vector3 nextPosition = model.position;
        nextPosition.y = Mathf.Lerp(nextPosition.y,modelDestination.y,t * Time.deltaTime);
        model.position = nextPosition;
        Debug.DrawLine(model.transform.position,modelDestination); 
    }
}
