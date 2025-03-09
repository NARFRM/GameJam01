using UnityEngine;

public class GlowingLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform pointA, pointB; // Dos puntos para la línea

    void Start()
    {
        lineRenderer.positionCount = 2; // Solo dos puntos
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);

        // Ajusta el grosor de la línea
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        // Activa la emisión si el material lo permite
        lineRenderer.material.EnableKeyword("_EMISSION");
        lineRenderer.material.SetColor("_EmissionColor", Color.yellow * 2); // Luz amarilla brillante
    }
}
