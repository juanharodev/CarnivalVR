using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] Rigidbody rb;
    [SerializeField] float minStickSpeed;

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject,lifeTime);
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

    }
}