using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePixels : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D sourceTexture;
    public Color targetColor = Color.red;
    public Color replacementColor = Color.blue;
    public float tolerance = 0.1f;
    private Color[] originalPixels;

    void Start()
    {
        originalPixels = sourceTexture.GetPixels();
        ChangeColor();
    }
    void Update()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        Color[] pixels = sourceTexture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            if (Vector4.Distance(pixels[i], targetColor) < tolerance)
            {
                pixels[i] = replacementColor;
            }
        }
        sourceTexture.SetPixels(pixels);
        sourceTexture.Apply();
    }

    void OnDisable()
    {
        if (sourceTexture != null && originalPixels != null)
        {
            sourceTexture.SetPixels(originalPixels);
            sourceTexture.Apply();

        }
    }

}