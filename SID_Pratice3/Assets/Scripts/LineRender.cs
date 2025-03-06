using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class LineRender : MonoBehaviour
{

    public int numberOfSides = 5; 
    public float radius = 5f;    
    public float centerX = 0f;    
    public float centerY = 0f;

    private LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>(); 
    }
    private void Update()
    {
        CreateShape();
    }

    void CreateShape()
    {
        if (numberOfSides < 3) return; // Un polígono necesita al menos 3 lados

        Vector3[] positions = new Vector3[numberOfSides + 1];
        float angleStep = 2 * Mathf.PI / numberOfSides;

        for (int i = 0; i < numberOfSides; i++)
        {
            float angle = i * angleStep;
            float x = centerX + Mathf.Cos(angle) * radius;
            float y = centerY + Mathf.Sin(angle) * radius;
            positions[i] = new Vector3(x, y, 0);
        }

        positions[numberOfSides] = positions[0]; 

        line.positionCount = positions.Length;
        line.SetPositions(positions);

    
        line.loop = true;
        line.numCornerVertices = 90;
        line.numCapVertices = 90;
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
    }
}
