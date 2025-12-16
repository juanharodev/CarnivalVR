using TMPro;
using UnityEngine;

public class RodScoreManager : MonoBehaviour
{
    public static RodScoreManager Instance;
    private int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AddScore(0);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }   


}
