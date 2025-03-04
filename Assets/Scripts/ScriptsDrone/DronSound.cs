using UnityEngine;

public class DronSound : MonoBehaviour
{
    public Transform player;        
    public AudioSource droneAudio;   // AudioSource del dron
    public float maxVolume = 1f;     // Volumen m�ximo cuando el jugador est� cerca
    public float minVolume = 0.1f;   // Volumen m�nimo cuando est� lejos
    public float maxDistance = 20f;  

    void Update()
    {
        if (player == null || droneAudio == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Calcular el volumen seg�n la distancia
        float volume = Mathf.Lerp(maxVolume, minVolume, distance / maxDistance);

        // Limitar el volumen entre minVolume y maxVolume
        droneAudio.volume = Mathf.Clamp(volume, minVolume, maxVolume);
    }
}
