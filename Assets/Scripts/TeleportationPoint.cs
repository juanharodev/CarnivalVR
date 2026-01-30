using UnityEngine;

public class TeleportationPoint : MonoBehaviour
{
    public Sprite icon;
    public string pointName;
    public Transform point;
    public LocationTp tpSystem;

    public void Teleport()
    {
        tpSystem.Teleport(point);
    }
}
