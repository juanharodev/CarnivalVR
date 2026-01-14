using UnityEngine;

public class TankBounds : MonoBehaviour
{
    public Vector3 size = new Vector3(10, 5, 10);

    public Vector3 Center => transform.position;

    public Vector3 GetRandomXZ()
    {
        return new Vector3(
            Random.Range(Center.x - size.x / 2, Center.x + size.x / 2),
            Center.y,
            Random.Range(Center.z - size.z / 2, Center.z + size.z / 2)
        );
    }

    public float GetRandomY()
    {
        return Random.Range(
            Center.y - size.y / 2,
            Center.y + size.y / 2
        );
    }

    public Vector3 ClampToBounds(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, Center.x - size.x / 2, Center.x + size.x / 2);
        position.z = Mathf.Clamp(position.z, Center.z - size.z / 2, Center.z + size.z / 2);
        position.y = transform.position.y;
        return position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, size);
    }
}