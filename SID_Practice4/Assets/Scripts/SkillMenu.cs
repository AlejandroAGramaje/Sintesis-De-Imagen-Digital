using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    public float attack = 50f;
    public float speed = 50f;
    public float health = 50f;
    public float defence = 50f;
    public float mana = 50f;
    public float strength = 50f;
    public float maxValue = 100f;
    public Material material;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        CreateSkillMesh();
    }

    void CreateSkillMesh()
    {
        float[] values = { attack, speed, health, defence, mana, strength };
        int numSkills = values.Length;
        Vector3[] vertices = new Vector3[numSkills + 1];
        int[] triangles = new int[numSkills * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < numSkills; i++)
        {
            float angle = i * Mathf.PI * 2f / numSkills;
            float normalizedValue = values[i] / maxValue;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * normalizedValue, Mathf.Sin(angle) * normalizedValue, 0);
        }

        for (int i = 0; i < numSkills; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2 > numSkills) ? 1 : i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
