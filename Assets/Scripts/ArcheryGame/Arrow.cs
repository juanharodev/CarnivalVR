using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] Rigidbody rb;
    [SerializeField] float minStickSpeed;
    public bool isDestructible;

    void OnTriggerEnter(Collider other)
    {
        if (isDestructible)
        {
            Destroy(gameObject,lifeTime);
        }
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

    }
}