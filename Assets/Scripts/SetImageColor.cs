using UnityEngine;
using UnityEngine.UI;

public class SetImageColor : MonoBehaviour
{
    [SerializeField] Image targetImage;
    [SerializeField] Image btnImage;
    [SerializeField] Color targetColor;

    private void Start()
    {
        btnImage.color = targetColor;
    }
    public void ChangeColor()
    {
        Debug.Log("Pushed Button");
        targetImage.color = targetColor;
    }
}
