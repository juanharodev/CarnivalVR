using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class RotateFromTo : MonoBehaviour
{
    [SerializeField] Transform from;
    [SerializeField] Transform to;
    [SerializeField] bool allowChangeWhileMoving;
    [SerializeField] float rotationSpeed;
    [SerializeField,Range(0.01f,1f)] float minAngle = 0.01f;
    bool isInFrom = true;
    bool isMoving;
    Coroutine rotationRoutine;
    public void Rotate()
    {
        if(isMoving && !allowChangeWhileMoving){return;}    
        if(rotationRoutine != null){StopCoroutine(rotationRoutine);}
        rotationRoutine = StartCoroutine(Rotation());
    }

    IEnumerator Rotation()
    {
        Quaternion destination =  isInFrom? to.rotation : from.rotation;
        isInFrom = !isInFrom;
        isMoving = true;
        while (minAngle < Quaternion.Angle(destination, transform.rotation))
        {
            yield return new WaitForEndOfFrame();
            transform.rotation = Quaternion.Slerp(transform.rotation,destination,Time.deltaTime * rotationSpeed);
        }
        isMoving = false;
    }
}
