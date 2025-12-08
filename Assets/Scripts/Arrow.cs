using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] Rigidbody rb;
    [SerializeField] float minStickSpeed;
    public bool isDestructible;

    void OnCollisionEnter(Collision collision)
    {
        if (isDestructible)
        {
            Destroy(gameObject,lifeTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDestructible)
        {
            Destroy(gameObject,lifeTime);
        }
        Debug.Log(rb.linearVelocity.magnitude);
        if(minStickSpeed < rb.linearVelocity.magnitude)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}