using UnityEngine;
using System.Collections;

public class LightBlink : MonoBehaviour
{
    public Light myLight;  // Arrastra aquí tu luz en el Inspector
    public float blinkInterval = 0.5f; // Tiempo entre parpadeos

    void Start()
    {
        StartCoroutine(BlinkLight()); // Iniciar el parpadeo
    }

    IEnumerator BlinkLight()
    {
        while (true)
        {
            myLight.enabled = !myLight.enabled; // Cambia el estado de la luz
            yield return new WaitForSeconds(blinkInterval); // Espera un tiempo
        }
    }
}
