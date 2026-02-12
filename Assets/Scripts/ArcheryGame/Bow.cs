using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Bow : MonoBehaviour
{
    [Header("Grab Points")]
    [SerializeField] Transform bowGrabPoint;
    [SerializeField] Transform bowstringGrabPoint;

    [Header("Arrow")]
    [SerializeField] GameObject arrowMesh;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float baseSpeed;
    public bool isUpdatingArrow;

    [SerializeField] BallonGame ballonGame;
    
    int grabCount = 0;

    void Start()
    {
        arrowMesh.SetActive(false);
    }

    void Update()
    {
        if (isUpdatingArrow){ UpdateArrow(); }  
    }

    public void StartShoot(SelectEnterEventArgs args)
    {
        //Event is called when grabbing object, Only activate it when grabbed by two hands
        grabCount++;
        Debug.Log("Grabbed " + grabCount);
        if(grabCount == 2) 
        {
            Debug.Log("Start updating");
            isUpdatingArrow = true;
            arrowMesh.SetActive(true);
            bowstringMiddle = args.interactorObject.transform;
        }
    }

    public void Shoot()
    {
        //Event is called when released. Only activate when one hand released and one still grabs
        grabCount--;
        if (grabCount != 1) return;
        ballonGame.ShootArrow();
        Vector3 direction = bowGrabPoint.position - bowstringMiddle.position;
        GameObject instance = Instantiate(arrowPrefab,bowstringGrabPoint.position, Quaternion.identity);
        instance.transform.forward = bowGrabPoint.forward;
        Rigidbody arrowRb =  instance.GetComponent<Rigidbody>();
        arrowRb.AddForce(direction * baseSpeed,ForceMode.Impulse);
        arrowRb.useGravity = true;
        bowstringGrabPoint.position = bowStringStart.position;
        arrowMesh.SetActive(false);
        isUpdatingArrow = false;
    }

    [Header("Bowstring")]
    [SerializeField] Transform bowStringStart;
    
    Transform bowstringMiddle;
    void UpdateArrow()
    {
        bowstringGrabPoint.position = bowstringMiddle.position;
        arrowMesh.transform.forward =  bowGrabPoint.position - bowstringMiddle.position;
    }
}
