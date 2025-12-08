using UnityEngine;

public class Fishnet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
