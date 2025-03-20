using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public Texture2D levelImage;
    public GameObject cubePrefab;
    public Transform parent;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int x = 0; x < levelImage.width; x++)
        {
            for (int y = 0; y < levelImage.height; y++)
            {
                Color pixelColor = levelImage.GetPixel(x, y);
                if (pixelColor == Color.black) // Only create cubes for non-transparent pixels
                {
                    Vector3 position = new Vector3(x, 0, y);
                    GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, parent);
                }
            }
        }
    }
}