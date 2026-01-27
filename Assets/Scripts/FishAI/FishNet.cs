using UnityEngine;

public class FishNet : MonoBehaviour
{
    public float CurrentSpeed {get; private set;}
    private Vector3 lastPosition;

    void OnEnable()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        CurrentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FishCollition>(out FishCollition fish))
        {
            fish.Collide();
        }
    }
}