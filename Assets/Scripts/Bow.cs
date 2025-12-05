using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] Transform bowGrabPoint;
    [SerializeField] Transform stringGrabPoint;
    [SerializeField] GameObject arrow;
    [SerializeField] float baseSpeed;


    public void StartShoot()
    {
        arrow.SetActive(true);
    }

    public void Shoot()
    {
        Vector3 direction = stringGrabPoint.position - bowGrabPoint.position;
        Quaternion rotation = Quaternion.FromToRotation(stringGrabPoint.position,bowGrabPoint.position);
        GameObject instance = Instantiate(arrow,stringGrabPoint.position, rotation);
        instance.GetComponent<Rigidbody>().AddForce(direction * baseSpeed,ForceMode.Impulse);
        arrow.SetActive(false);
    }
}
