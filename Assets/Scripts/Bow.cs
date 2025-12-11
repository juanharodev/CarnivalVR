using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Bow : MonoBehaviour
{
    [Header("Grab Points")]
    [SerializeField] Transform bowGrabPoint;
    [SerializeField] Transform bowstringGrabPoint;

    [Header("Arrow")]
    [SerializeField] GameObject arrow;
    [SerializeField] float baseSpeed;
    public bool isUpdatingArrow;
    
    int grabCount = 0;

    void Start()
    {
        bowstringMiddle = bowstringGrabPoint;
        UpdateLine();
        arrow.SetActive(false);
    }

    void Update()
    {
        UpdateLine();
        if (isUpdatingArrow){ UpdateArrow(); }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isUpdatingArrow = true;
            arrow.SetActive(true);
            grabCount = 2;
            Shoot();
        }
    }

    public void StartShoot(SelectEnterEventArgs args)
    {
        //Event is called when grabbing object, Only activate it when grabbed by two hands
        grabCount++;
        if(grabCount == 2) 
        {
            isUpdatingArrow = true;
            arrow.SetActive(true);
            bowstringMiddle = args.interactorObject.transform;
        }
    }

    public void Shoot()
    {
        //Event is called when released. Only activate when one hand released and one still grabs
        grabCount--;
        if (grabCount != 1) return;
        Vector3 direction = bowGrabPoint.position - bowstringMiddle.position;
        GameObject instance = Instantiate(arrow,bowstringGrabPoint.position, Quaternion.identity);
        instance.transform.up = bowGrabPoint.forward;
        Rigidbody arrowRb =  instance.GetComponent<Rigidbody>();
        arrowRb.AddForce(direction * baseSpeed,ForceMode.Impulse);
        arrowRb.useGravity = true;
        instance.GetComponent<Arrow>().isDestructible = true;
        bowstringMiddle = bowstringGrabPoint;
        arrow.SetActive(false);
        isUpdatingArrow = false;
    }

    [Header("Bowstring")]
    public LineRenderer lineRenderer;
    [SerializeField] Transform bowstringUp;
    Transform bowstringMiddle;
    [SerializeField] Transform bowstringDown;

    void UpdateLine()
    {
        lineRenderer.SetPosition(0,bowstringUp.position);
        lineRenderer.SetPosition(1,bowstringMiddle.position);
        lineRenderer.SetPosition(2,bowstringDown.position);
    }
    void UpdateArrow()
    {
        arrow.transform.position = bowstringMiddle.transform.position;
        arrow.transform.up =  bowGrabPoint.position - bowstringMiddle.position;
    }
}
