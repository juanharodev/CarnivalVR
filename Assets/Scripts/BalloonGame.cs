using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallonGame : MonoBehaviour
{
    [SerializeField] private List<Balloon> balloons;

    [SerializeField] Transform bowStartPoint;
    [SerializeField] Rigidbody bow;

    void Awake()
    {
        foreach(Balloon b in balloons)
        {
            b.gameObject.SetActive(false);
        }
    }
    public void Initialize()
    {
        bow.linearVelocity = Vector3.zero;
        bow.angularVelocity = Vector3.zero;
        bow.transform.SetPositionAndRotation(bowStartPoint.position,bowStartPoint.rotation);
        bow.gameObject.SetActive(true);
        foreach(Balloon b in balloons)
        {
            b.Initialize();
        }
    }
}