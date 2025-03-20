using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelVoxel : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D voxelImage;
    public GameObject voxelPrefab;
    private GameObject[,] voxels;

    void Start()
    {
        GenerateVoxels();
    }

    void GenerateVoxels()
    {
        voxels = new GameObject[voxelImage.width, voxelImage.height];
        for (int x = 0; x < voxelImage.width; x++)
        {
            for (int y = 0; y < voxelImage.height; y++)
            {
                Color pixelColor = voxelImage.GetPixel(x, y);
                if (pixelColor.a > 0)
                {
                    Vector3 position = new Vector3(x, y, 0);
                    GameObject voxel = Instantiate(voxelPrefab, position, Quaternion.identity, transform);
                    voxel.GetComponent<Renderer>().material.color = pixelColor;
                    voxels[x, y] = voxel;
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyVoxels();
        }
    }

    void DestroyVoxels()
    {
        foreach (var voxel in voxels)
        {
            if (voxel != null)
            {
                Rigidbody rb = voxel.AddComponent<Rigidbody>();
                rb.useGravity = true;
            }
        }
    }
}
