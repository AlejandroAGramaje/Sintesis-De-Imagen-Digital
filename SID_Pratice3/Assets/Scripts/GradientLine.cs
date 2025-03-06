using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientLine : MonoBehaviour
{
    public float widthLine = 0.1f; // Grosor de la línea

    public GameObject prefabsLine; // Prefab de la línea
    public Transform parentLines; // Contenedor de las líneas

    public Color color1, color2; // Color inicial y final

    void Start()
    {
        Gradient(color1, color2);
    }

    void Gradient(Color startColor, Color endColor)
    {
        // Obtener dimensiones de la cámara
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize; // Altura total visible
        float camWidth = camHeight * cam.aspect; // Ancho total visible

        // Calcular número de líneas dinámicamente
        int lineCount = Mathf.RoundToInt(camHeight / widthLine);

        for (int i = 0; i < lineCount; i++)
        {
            // Calcular color interpolado
            Color currentColor = Color.Lerp(startColor, endColor, (float)i / (lineCount - 1));

            // Instanciar una línea desde el prefab
            GameObject line = Instantiate(prefabsLine, parentLines);
            line.transform.position = new Vector3(0, -camHeight / 2 + i * widthLine, 0);

            // Configurar Line Renderer
            LineRenderer lr = line.GetComponent<LineRenderer>();
            lr.startColor = currentColor;
            lr.endColor = currentColor;
            lr.positionCount = 2;
            lr.SetPosition(0, new Vector3(-camWidth / 2, line.transform.position.y, 0));
            lr.SetPosition(1, new Vector3(camWidth / 2, line.transform.position.y, 0));

            // Ajustar el grosor de la línea
            lr.startWidth = widthLine;
            lr.endWidth = widthLine;
        }
    }
}
