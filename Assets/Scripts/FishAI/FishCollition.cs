using UnityEngine;

public class FishCollition : MonoBehaviour
{
    [SerializeField] Transform root;
    public void Collide()
    {
        root.gameObject.SetActive(false);
    }
}