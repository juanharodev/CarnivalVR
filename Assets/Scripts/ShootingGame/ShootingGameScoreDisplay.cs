using TMPro;
using UnityEngine;

public class ShootingGameScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lblTargetCount;
    [SerializeField] TextMeshProUGUI lblBulletsCount;

    public void DisplayScore(ShootingGameScore score)
    {
        lblTargetCount.text = score.targetsHit + "\n--\n" + "15";
        lblBulletsCount.text = (score.bulletsUsed <= 99? score.bulletsUsed : 99).ToString();
    }
}

public struct ShootingGameScore
{
    public int targetsHit;
    public int bulletsUsed;
}