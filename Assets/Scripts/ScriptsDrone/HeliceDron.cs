using UnityEngine;

public class HeliceDron : MonoBehaviour
{
    public float rotationSpeed = 500f; 

    void Update()
    {
        // Rotar sobre el eje Z (puede ser X o Y dependiendo de tu modelo)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
