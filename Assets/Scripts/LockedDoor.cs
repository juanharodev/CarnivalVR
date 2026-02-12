using UnityEngine;
using UnityEngine.Events;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] bool isLocked;
    [SerializeField] UnityEvent OnSuccesfullActivation;
    [SerializeField] UnityEvent OnFailedActivation;
    public void TryActivate()
    {
        if (isLocked)
        {
            OnFailedActivation?.Invoke();
        }
        else
        {
            OnSuccesfullActivation?.Invoke();
        }
    }

    [SerializeField] UnityEvent OnUnlock;
    public void Unlock()
    {
        isLocked = false;
        OnUnlock?.Invoke();
    }

    [SerializeField] UnityEvent OnLock;
    public void Lock()
    {
        isLocked = true;
        OnLock?.Invoke();
    }
}
