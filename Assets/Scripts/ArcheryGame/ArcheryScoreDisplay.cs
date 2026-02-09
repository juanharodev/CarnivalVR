using TMPro;
using UnityEngine;

public class ArcheryScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lblTimeDisplay;
    [SerializeField] TextMeshProUGUI lblArrowsDisplay;

    public void UpdateTime(int newTime)
    {
        int seconds = newTime % 60;
        int minutes = newTime/60;
        minutes = minutes<=99? minutes : 99;
        lblTimeDisplay.text = minutes.ToString("D2") + ":"+ seconds.ToString("D2");
    }

    public void UpdateArrows(int newArrows)
    {
        lblArrowsDisplay.text = (newArrows<=999? newArrows : 999).ToString("D3");
    }

    public void UpdateDisplay(ArcheryScore score)
    {
        UpdateTime(score.time);
        UpdateArrows(score.arrows);
    }

}