using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Fish : MonoBehaviour
{
    [Header("Navigation")]
    private NavMeshAgent agent;
    [SerializeField] Transform centerPoint;
    [SerializeField] float arriveDistance;
    [SerializeField] float searchRadius;

    
    [Header("Stop time")]
    [SerializeField] float minStopTime;
    [SerializeField,] float maxStopTime;    
    

    [Header("Model movement")]
    [SerializeField] Vector3 size;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform model;
    [SerializeField] float t;
    Vector3 viewDirection;

    Vector3 modelDestination;

    bool isStoped;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + offset,size);

        if(centerPoint == null){return;}
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centerPoint.position,searchRadius);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isStoped && HasArravied())
        {
            StartCoroutine(StopFish());
        }
        MoveModel();
    }    
    bool HasArravied()
    {
        if (!agent.hasPath){ SetDestination(); }

        Vector2 currentPost = new Vector2(transform.position.x,transform.position.z);
        Vector2 destination = new Vector2(agent.destination.x,agent.destination.z);
        return Vector2.Distance(currentPost,destination) < arriveDistance;
    }

    IEnumerator StopFish()
    {
        isStoped = true;
        float waitTime = Random.Range(minStopTime,maxStopTime);
        yield return new WaitForSeconds(Mathf.Abs(waitTime));
        SetDestination();
        isStoped = false;

    }

    void SetDestination()
    {
        bool found = false;
        while (!found)
        {
            Vector3 destination = centerPoint.position + (Random.insideUnitSphere * searchRadius);
            if(NavMesh.SamplePosition(destination,out NavMeshHit hit, searchRadius, NavMesh.AllAreas)){
                agent.SetDestination(hit.position);
                modelDestination = hit.position;
                modelDestination.y = RandomYMoveRange();
                found = true;
            }
        }
    }

    void MoveModel()
    {
        viewDirection = modelDestination - model.transform.position; 
        model.forward = viewDirection == Vector3.zero? model.forward : viewDirection;
        Vector3 nextPosition = model.position;
        nextPosition.y = Mathf.Lerp(nextPosition.y,modelDestination.y,t * Time.deltaTime);
        model.position = nextPosition;
        Debug.DrawLine(model.transform.position,modelDestination); 
    }

    float RandomYMoveRange()
    {
        float min = transform.position.y + offset.y;
        return Random.Range(min,min + size.y); 
    }


}
