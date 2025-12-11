using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] List<Color> colors;
    [SerializeField] Renderer targetRenderer;
    MaterialPropertyBlock propertyBlock;

    void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    public void ChangeColor()
    {
        int i = Random.Range(0,colors.Count);
        propertyBlock.SetColor("_BaseColor",colors[i]);
        targetRenderer.SetPropertyBlock(propertyBlock);
    }
}
