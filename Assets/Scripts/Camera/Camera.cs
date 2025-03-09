using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El jugador
    public float distance = 3.0f; // Distancia de la cámara
    public float smoothSpeed = 10f;
    public LayerMask obstacleMask; // Capas que bloquean la cámara

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 1.5f, -distance); // Offset inicial de la cámara
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 direction = desiredPosition - target.position;

        RaycastHit hit;
        if (Physics.Raycast(target.position, direction.normalized, out hit, distance, obstacleMask))
        {
            // Si la cámara choca con algo, la mueve al punto de colisión
            desiredPosition = hit.point;
        }

        // Mueve la cámara suavemente
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.LookAt(target.position);
    }
}
