using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishManager : MonoBehaviour
{
    [SerializeField] Rigidbody net;
    [SerializeField] Transform netStartPosition;
    [SerializeField] List<Transform> fishes;

    void Start()
    {
        net.gameObject.SetActive(false);
        foreach(Transform t in fishes)
        {
            t.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        foreach(Transform t in fishes)
        {
            t.gameObject.SetActive(true);
        }
        net.gameObject.SetActive(false);
        net.linearVelocity = Vector3.zero;
        net.angularVelocity = Vector3.zero;
        net.transform.position = netStartPosition.position;
        net.transform.rotation = netStartPosition.rotation;
        net.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartGame();
        }
    }
}