using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public int sides = 3;
    public float radius = 1f;
    public Material material;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        
    }
    void Update()
    {
        CreatePolygon();
    }
    void CreatePolygon()
    {
        Vector3[] vertices = new Vector3[sides + 1];
        int[] triangles = new int[sides * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < sides; i++)
        {
            float angle = i * Mathf.PI * 2f / sides;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
        }

        for (int i = 0; i < sides; i++)
        {
            triangles[i * 3] = (i + 2 > sides) ? 1 : i + 2; 
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = 0;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
