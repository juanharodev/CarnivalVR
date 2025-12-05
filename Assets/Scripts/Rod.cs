using UnityEngine;

public class Rod : MonoBehaviour
{
    [SerializeField] int points = 10;

    public void AddPoints()
    {
        RodScoreManager.Instance.AddScore(points);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
