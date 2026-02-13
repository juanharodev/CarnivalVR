using UnityEngine;
using UnityEngine.Events;

public class TriggerPlatform : MonoBehaviour
{
    [SerializeField] UnityEvent OnTriggerActivation;

    void OnTriggerEnter(Collider other)
    {
        OnTriggerActivation?.Invoke();
    }
}
