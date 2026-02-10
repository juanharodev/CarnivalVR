using UnityEngine;

public class FollowOnX : MonoBehaviour
{
    [SerializeField] float lenght;
    [SerializeField] Transform target;
    Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        Vector3 updatedPos = startPos;
        updatedPos.x = Mathf.Clamp(target.transform.position.x,startPos.x - (lenght * 0.5f),startPos.x + (lenght * 0.5f));
        transform.position = updatedPos;
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
        }
        else
        {
            Vector3 start = transform.position;
            start.x -= lenght* 0.5f;
            Vector3 end = transform.position;
            end.x += lenght*0.5f;
            Gizmos.DrawLine(start,end);
        }
    }
}
