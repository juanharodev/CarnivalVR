using System.Collections.Generic;
using UnityEngine;

public class HeadCollitionHandler : MonoBehaviour
{
    [SerializeField]
    HeadCollisionDetector detector;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    float pushBackStrength = 1.0f;

    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach(RaycastHit hit in colliderHits)
        {
            combinedNormal += new Vector3(hit.normal.x,0,hit.normal.z);
        }    
        return combinedNormal;
    }

    void Update()
    {
        if(detector.DetectedColliderHits.Count <= 0)
        {
            return;
        }

        Vector3 pushBackDirection = CalculatePushBackDirection(detector.DetectedColliderHits);

        characterController.Move(Time.deltaTime * pushBackStrength * pushBackDirection.normalized);
    }

}
